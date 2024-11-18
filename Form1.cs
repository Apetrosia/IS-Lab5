using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace IS_Lab5
{
    public partial class Form1 : Form
    {
        List<State> states = new List<State>();
        List<(int, int)> outProds = new List<(int, int)>();
        List<string> factsList = new List<string>();
        HashSet<string> finals;
        Dictionary<string, bool> facts = new Dictionary<string, bool>();
        Dictionary<string, string> descriptions = new Dictionary<string, string>();
        List<string> products = new List<string>();
        string finalFact;

        public Form1()
        {
            InitializeComponent();
            foreach (string line in File.ReadLines("facts.txt"))
            {
                if (line.Length == 0 || line[0] == '#')
                    continue;
                factsList.Add(line.Split('-')[0]);
                facts.Add(line.Split('-')[0], false);
                descriptions.Add(line.Split('-')[0], line.Split('-')[1]);
            }
            foreach (string line in File.ReadLines("products.txt"))
            {
                if (line.Length == 0 || line[0] == '#')
                    continue;
                products.Add(line);
            }
            finals = new HashSet<string> { "VWP", "VWTG", "VWG", "VWTR", "BMWX", "BMWZ", "DM", "HS", "LN" };

            activityListBox.SelectedIndex = 0;
            familyListBox.SelectedIndex = 0;
            commListBox.SelectedIndex = 0;
            goodsListBox.SelectedIndex = 0;
            tripsListBox.SelectedIndex = 0;
            natureListBox.SelectedIndex = 0;
            carListBox.SelectedIndex = 0;
            algListBox.SelectedIndex = 0;
        }

        private void findCar_Click(object sender, EventArgs e)
        {

            SetFacts();
            outProds.Clear();

            switch (carListBox.SelectedIndex)
            {
                case 0:
                    finalFact = "VWP";
                    break;
                case 1:
                    finalFact = "VWTG";
                    break;
                case 2:
                    finalFact = "VWTR";
                    break;
                case 3:
                    finalFact = "VWG";
                    break;
                case 4:
                    finalFact = "BMWX";
                    break;
                case 5:
                    finalFact = "BMWZ";
                    break;
                case 6:
                    finalFact = "DM";
                    break;
                case 7:
                    finalFact = "HS";
                    break;
                case 8:
                    finalFact = "LN";
                    break;
            }

            SetTestfacts();

            if (algListBox.SelectedIndex == 0)
                DirectSearch();
            else
                ReverseSearch();
        }

        public void DirectSearch()
        {
            states.Clear();

            foreach (string key in facts.Keys)
                if (facts[key])
                    states.Add(new State(key));

            int oldSize = -1;

            //while (!finals.Contains(states[states.Count - 1].fact))
            while (oldSize != states.Count && states[states.Count - 1].fact != finalFact)
            {
                oldSize = states.Count;
                List<int> prevs = new List<int>();
                int l = 0;

                // Проходимся по всем продукциям
                for (int i = 0; i < products.Count; i++)
                {
                    if (finals.Contains(products[i].Split('-')[1]) && !finalFact.Equals(products[i].Split('-')[1]))
                        continue;
                    // Если факт еще не получен, смотрим продукцию
                    if (!facts[products[i].Split('-')[1]])
                    {
                        bool res = true;

                        // Смотрим каждый факт в продукции слева (или сложение фактов)
                        foreach (string mult in products[i].Split('-')[0].Split(','))
                        {
                            if (!facts[mult])
                            {
                                res = false;
                                break;
                            }
                            for (int t = 0; t < states.Count; t++)
                                if (states[t].fact == mult)
                                {
                                    // Добавляем ссылки на все посылки
                                    l = Math.Max(l, states[t].layer);
                                    prevs.Add(t);
                                    break;
                                }
                        }

                        // Если продукция верная, добавляем ее
                        if (res)
                        {
                            facts[products[i].Split('-')[1]] = true;
                            states.Add(new State(products[i].Split('-')[1], i, l + 1, prevs));
                            foreach (int prev in prevs)
                                states[prev].nexts.Add(states.Count - 1);
                            outProds.Add((l, i));
                        }
                    }
                }
            }

            Output();
            MakeDescription(states[states.Count - 1].layer);
        }

        public void ReverseSearch()
        {
            states.Clear();
            states.Add(new State(finalFact));

            HashSet<string> inputFacts = new HashSet<string>();
            foreach (string key in facts.Keys)
                if (facts[key])
                    inputFacts.Add(key);
            HashSet<string> currFacts = new HashSet<string>();
            HashSet<int> prods = new HashSet<int>();

            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            int max_layer = 0;

            while (stack.Count > 0)
            {
                int curr = stack.Pop();

                // Если узел - факт
                if (states[curr].product == -1)
                {
                    string fact = states[curr].fact;

                    // Если факт входит в множество входных фактов, помечаем узел как решенный
                    if (inputFacts.Contains(fact))
                    {
                        Queue<int> queue = new Queue<int>();
                        queue.Enqueue(curr);

                        // Помечаем узлы, которые стали решенными (если стали)
                        while (queue.Count > 0)
                        {
                            int ind = queue.Dequeue();
                            // Если узел - продукция
                            if (states[ind].product != -1)
                            {
                                states[ind].solved = true;
                                // Проверяем, все ли посылки решенные
                                foreach (int j in states[ind].prevs)
                                {
                                    if (!states[j].solved)
                                    {
                                        states[ind].solved = false;
                                        break;
                                    }
                                }
                                if (states[ind].solved)
                                    foreach (int t in states[ind].nexts)
                                        queue.Enqueue(t);
                            }
                            else // Если узел - факт
                            {
                                states[ind].solved = true;
                                foreach (int j in states[ind].nexts)
                                    queue.Enqueue(j);
                            }
                        }
                        if (states[0].solved)
                            break;
                    }
                    else
                        for (int i = 0; i < products.Count; i++)
                        {
                            // Добавляем продукции, с помощью которых можно вывести этот факт
                            if (products[i].Split('-')[1].Equals(fact))
                            {
                                // Если продукции еще нет в дереве
                                if (prods.Add(i))
                                {
                                    states.Add(new State(products[i], i, states[curr].layer + 1, new List<int>()));
                                    states[states.Count - 1].nexts.Add(curr);
                                    states[curr].prevs.Add(states.Count - 1);
                                    stack.Push(states.Count - 1);
                                    max_layer = Math.Max(max_layer, states[states.Count - 1].layer);
                                }
                                else // Если продукция уже есть в дереве
                                {
                                    for (int j = 0; j < states.Count; j++)
                                    {
                                        if (states[j].product == i)
                                        {
                                            states[curr].prevs.Add(j);
                                            states[j].nexts.Add(curr);
                                            if (states[j].solved)
                                                stack.Push(j);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                }
                else // если узел - продукция
                {
                    string[] mults = products[states[curr].product].Split('-')[0].Split(',').ToArray();
                    int mx = mults.Length;
                    for (int i = 0; i < mx; i++)
                    {
                        // рассматриваем все факты в посылке
                        if (currFacts.Add(mults[i]))
                        {
                            // Добавляем их, если их не было
                            states.Add(new State(mults[i], -1, states[curr].layer, new List<int>()));
                            states[states.Count - 1].nexts.Add(curr);
                            states[curr].prevs.Add(states.Count - 1);
                            stack.Push(states.Count - 1);
                            max_layer = Math.Max(max_layer, states[states.Count - 1].layer);
                        }
                        else // если факт уже есть в дереве, добавляем индексы в prevs и nexts
                        {
                            for (int j = 0; j < states.Count; j++)
                            {
                                if (states[j].product != -1)
                                    continue;
                                if (mults[i].Equals(states[j].fact))
                                {
                                    states[j].nexts.Add(curr);
                                    states[curr].prevs.Add(j);
                                    if (states[j].solved)
                                        stack.Push(j);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            Output(true, max_layer);
            MakeDescription(max_layer, true);
        }

        public void Output(bool reverse = false, int max_layer = -1)
        {
            descriptionTextBox.Text = "";
            string res = "";
            textBox1.Text = res;
            if (finalFact == "f00")
                descriptionTextBox.Text = "finalFact = \"f00\"";

            if (!reverse)
            {
                if (states[states.Count - 1].fact != finalFact)
                {
                    textBox1.Text = "Вывод невозможен";
                    return;
                }
                int i = 0;
                int j = 0;
                textBox1.Lines = new string[0];

                for (int cl = 0;  cl <= states[states.Count - 1].layer; cl++)
                {
                    res = "";
                    while (i < states.Count && states[i].layer == cl)
                        res += states[i++].fact + ",  ";
                    textBox1.AppendText(res + Environment.NewLine);
                    res = "";
                    while (j < outProds.Count && outProds[j].Item1 == cl)
                        res += products[outProds[j++].Item2] + ",  ";
                    textBox1.AppendText(res + Environment.NewLine + Environment.NewLine);
                }
            }
            else
            {
                if (!states[0].solved)
                {
                    textBox1.Text = "Вывод невозможен";
                    return;
                }

                HashSet<string> hs = new HashSet<string>();
                HashSet<string> hs1 = new HashSet<string>();

                for (int layer = max_layer; layer >= 0; layer--)
                {
                    for (int i = 0; i < states.Count; i++)
                        if (states[i].product == -1 && states[i].solved && states[i].layer == layer && hs.Add(states[i].fact))
                            textBox1.AppendText(states[i].fact + ",  ");
                    textBox1.AppendText(Environment.NewLine);
                    for (int i = 0; i < states.Count; i++)
                        if (states[i].product != -1 && states[i].solved && states[i].layer == layer && hs.Add(states[i].fact) && hs1.Add(states[i].fact.Split('-')[1]))
                            textBox1.AppendText(states[i].fact + ",  ");
                    textBox1.AppendText(Environment.NewLine + Environment.NewLine);
                }
            }
        }

        public void MakeDescription(int maxLayer, bool reverse = false)
        {
            if (!reverse)
            {
                if (states[states.Count - 1].fact != finalFact)
                {
                    descriptionTextBox.Text = "Вывод невозможен";
                    return;
                }
                int count = 0;
                for (int cl = 0; cl < maxLayer; cl++)
                {
                    foreach ((int, int) fact in outProds)
                    {
                        if (fact.Item1 == cl)
                        {
                            count++;
                            descriptionTextBox.AppendText(fact.Item2 + ". ");
                            foreach (string f in products[fact.Item2].Split('-')[0].Split(','))
                            {
                                descriptionTextBox.AppendText(descriptions[f] + ", ");
                            }
                            descriptionTextBox.AppendText("следовательно " + descriptions[products[fact.Item2].Split('-')[1]] + ". ");
                            descriptionTextBox.AppendText(Environment.NewLine);
                        }
                    }
                        descriptionTextBox.AppendText(Environment.NewLine + Environment.NewLine);
                }

                descriptionTextBox.AppendText("Количество примененных продукций: " + outProds.Count);
            }
            else
            {
                if (!states[0].solved)
                {
                    descriptionTextBox.Text = "Вывод невозможен";
                    return;
                }
                int count = 0;
                for (int cl = maxLayer; cl >= 0; cl--)
                {
                    for (int i = 0; i < states.Count; i++)
                    {
                        if (states[i].product == -1)
                            continue;
                        if (states[i].layer == cl && states[i].solved)
                        {
                            descriptionTextBox.AppendText(states[i].product + ". ");
                            count++;
                            foreach (string f in products[states[i].product].Split('-')[0].Split(','))
                            {
                                descriptionTextBox.AppendText(descriptions[f] + ", ");
                            }
                            descriptionTextBox.AppendText("следовательно " + descriptions[products[states[i].product].Split('-')[1]] + ". ");
                            descriptionTextBox.AppendText(Environment.NewLine);
                        }
                    }
                        descriptionTextBox.AppendText(Environment.NewLine + Environment.NewLine);
                }
                descriptionTextBox.AppendText("Количество примененных продукций: " + count);
            }
        }

        private void SetTestfacts()
        {
            finalFact = "f00";
            foreach (string line in File.ReadLines("facts1.txt"))
            {
                if (line.Length == 0 || line[0] == '#')
                    continue;
                if (factsList.Contains(line.Split('-')[0]))
                    return;
                factsList.Add(line.Split('-')[0]);
                facts.Add(line.Split('-')[0], false);
                descriptions.Add(line.Split('-')[0], line.Split('-')[1]);
            }
            foreach (string line in File.ReadLines("rules1.txt"))
            {
                if (line.Length == 0 || line[0] == '#')
                    continue;
                products.Add(line);
            }
        }

        public void SetFacts()
        {
            switch (activityListBox.SelectedIndex)
            {
                case 0:
                    facts["TAS"] = true;
                    facts["TAW"] = false;
                    facts["TAB"] = false;
                    break;
                case 1:
                    facts["TAS"] = false;
                    facts["TAW"] = true;
                    facts["TAB"] = false;
                    break;
                case 2:
                    facts["TAS"] = false;
                    facts["TAW"] = false;
                    facts["TAB"] = true;
                    break;
            }

            switch (familyListBox.SelectedIndex)
            {
                case 0:
                    facts["FSS"] = true;
                    facts["FSF"] = false;
                    facts["FSC"] = false;
                    break;
                case 1:
                    facts["FSS"] = false;
                    facts["FSF"] = true;
                    facts["FSC"] = false;
                    break;
                case 2:
                    facts["FSS"] = false;
                    facts["FSF"] = false;
                    facts["FSC"] = true;
                    break;
            }

            switch (commListBox.SelectedIndex)
            {
                case 0:
                    facts["CR"] = true;
                    facts["CM"] = false;
                    facts["CO"] = false;
                    break;
                case 1:
                    facts["CR"] = false;
                    facts["CM"] = true;
                    facts["CO"] = false;
                    break;
                case 2:
                    facts["CR"] = false;
                    facts["CM"] = false;
                    facts["CO"] = true;
                    break;
            }

            switch (goodsListBox.SelectedIndex)
            {
                case 0:
                    facts["CGN"] = true;
                    facts["CGR"] = false;
                    facts["CGO"] = false;
                    break;
                case 1:
                    facts["CGN"] = false;
                    facts["CGR"] = true;
                    facts["CGO"] = false;
                    break;
                case 2:
                    facts["CGN"] = false;
                    facts["CGR"] = false;
                    facts["CGO"] = true;
                    break;
            }

            switch (tripsListBox.SelectedIndex)
            {
                case 0:
                    facts["TCN"] = true;
                    facts["TCR"] = false;
                    facts["TCO"] = false;
                    break;
                case 1:
                    facts["TCN"] = false;
                    facts["TCR"] = true;
                    facts["TCO"] = false;
                    break;
                case 2:
                    facts["TCN"] = false;
                    facts["TCR"] = false;
                    facts["TCO"] = true;
                    break;
            }

            switch (natureListBox.SelectedIndex)
            {
                case 0:
                    facts["TNN"] = true;
                    facts["TNR"] = false;
                    facts["TNO"] = false;
                    break;
                case 1:
                    facts["TNN"] = false;
                    facts["TNR"] = true;
                    facts["TNO"] = false;
                    break;
                case 2:
                    facts["TNN"] = false;
                    facts["TNR"] = false;
                    facts["TNO"] = true;
                    break;
            }

            for (int i = 18; i < factsList.Count; i++)
                facts[factsList[i]] = false;
        }
    }

    public class State
    {
        public string fact;
        public int product;
        public int layer;
        public bool solved;
        public int solvedCount;
        public List<int> prevs;
        public List<int> nexts;

        public State(string fact, int product, int layer, List<int> prevs)
        {
            this.fact = fact;
            this.product = product;
            this.layer = layer;
            solved = false;
            solvedCount = 0;
            this.prevs = prevs;
            nexts = new List<int>();
        }

        public State(string fact)
        {
            this.fact = fact;
            product = -1;
            layer = 0;
            solved = false;
            solvedCount = 0;
            prevs = new List<int>();
            nexts = new List<int>();
        }
    }
}
