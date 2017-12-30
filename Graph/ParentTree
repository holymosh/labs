public class ParentTree
    {
        public int[] ParentsToChild { get; } //Массив отношения дочерних узлов к предкам 
        public int[] Heights { get; } //Массив стоимости ребра

        public ParentTree(int[] parentsToChild, int[] heights)  // тут все понятно со 2 семестра
        {
            ParentsToChild = parentsToChild;
            Heights = heights;
        }

        public Dictionary<int,int> FindAllHeights() // метод нахождения всех конечных вершин и их высот
        {
            var treeEnds = FindAllTreeEnds(); // находим вершины у которых нет предков
            var result= new Dictionary<int, int>(); // словарь содержащий номер вершины и высоту до нее
            foreach (var treeEnd in treeEnds)
            {
                var currentNode = treeEnd; // начинаем с самой вершины
                var height = 0;
                while (!treeEnds[currentNode].Equals(-1))
                {
                    height += Heights[currentNode]; // берем стоимость до предка 
                    currentNode = treeEnds[currentNode]; // берем самого предка
                }
                result.Add(treeEnd,height);
            }
            return result;
        }

        private List<int> FindAllTreeEnds()
        {
            var result = new List<int>();
            foreach (var node in ParentsToChild) //находим все вершины у которых нет дочерних
            {
                if (!ParentsToChild.Contains(node))
                    result.Add(node);
            }
            return result;
        }
    }
