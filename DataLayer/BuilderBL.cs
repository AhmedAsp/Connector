using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALGenerator.DataLayer
{
    class BuilderBL
    {
        DBHelper Helper = new DBHelper();
        public string GetClassHeader(string Name)
        {
            string Header = "using " + Properties.Settings.Default.ProjName + ".DAL;\nusing System;\n using System.Collections.Generic;\n using System.Linq;\n using System.Text;\n";
            Header += "\n namespace " + Properties.Settings.Default.ProjName + ".BL";
            Header += "\n{\n public class " + Name + " : " + Properties.Settings.Default.ProjName + ".DAL." + Name + "\n{\n";
            return Header;
        }
        public string BuildConstructor(string Name)
        {
            string Result = "public " + Name + "()\n";
            Result += "        {\n        }\n";
            Result += "        public " + Name + "(DAL." + Name + " _DalObj)\n        {\n";
            List<Column> Cols = Helper.GetColumns(Name);
            foreach (Column Col in Cols)
            {
                Result += Col.Name+" = _DalObj."+Col.Name+";\n";
            }
            Result += "}";
            return Result;
        }
        public string BuildGetAll(string Name)
        {
            string Result = "public List<" + Name + "> GetAll()\n";
            Result += "{\n";
            Result += "List<DAL." + Name + "> lstObj = base.GetAll();\n";
            Result += "List<" + Name + "> Result = new List<" + Name + ">();\n";
            Result += "foreach (DAL." + Name + " Obj in lstObj)\n";
            Result += "{\n";
            Result += "    Result.Add(new " + Name + "(Obj));\n";
            Result += "        }\n";
            Result += "return Result;\n";
            Result += "        }\n";
            return Result;
        }
        public string BuildBasics(string Name)
        {
            string Result = "public void Update"+Name+"()";
            Result += "{\n";
            Result += "base.Update();\n";
            Result += "}\n";
            Result += "public void Add" + Name + "()";
            Result += "{\n";
            Result += "base.Insert();\n";
            Result += "}\n";
            Result += "public void Delete" + Name + "()";
            Result += "{\n";
            Result += "base.Delete();\n";
            Result += "}\n";
            return Result;
        }
        public string GetClassFooter(string Name)
        {
            string Footer = "\n}\n}";
            return Footer;
        }
        public string BuildClassDAL(string _TableName)
        {
            string DALClass = GetClassHeader(_TableName);
            DALClass += BuildConstructor(_TableName);
            DALClass += BuildGetAll(_TableName);
            DALClass += BuildBasics(_TableName);
            DALClass += GetClassFooter(_TableName);
            return DALClass;
        }
    }
}
