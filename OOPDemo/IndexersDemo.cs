using System;

namespace OOPsDemo
{
    internal class IndexersDemo
    {
        static void Main(string[] args)
        {
            Element element = new Element();
            Parameter parameter = element[BuiltInParameter.Mark];
            parameter.value = "Mark";
        }
    }

    public class Parameter
    {
        public BuiltInParameter BuiltInParameter { get; }
        public string value { get; set; }

        public Parameter(BuiltInParameter builtInParameter)
        {
            BuiltInParameter = builtInParameter;
        }
    }

    public class Element
    {
        public Parameter this[BuiltInParameter builtInParameter]
        {
            get
            {
                return new Parameter(builtInParameter);
            }
        }
    }
}
