using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALGenerator.DataLayer
{
    class Builder
    {
        DBHelper Helper = new DBHelper();
        public string GetClassHeader(string Name)
        {
            string Header = "using System;\n using System.Collections.Generic;\n using System.Linq;\n using System.Text;\n";
            Header += "\n namespace "+Properties.Settings.Default.ProjName+".DAL" ;
            Header += "\n{\n public class " + Name + "\n{\n";
            return Header;
        }
        public string GetClassVariables(string TableName)
        {
            string VariablesString = "\n#region Variables\n";
            VariablesString += "DBGate Gate = new DBGate();\n";
            VariablesString += "#endregion Variables\n";
            return VariablesString;
        }
        public string GetClassProperties(string TableName)
        {
            List<Column> Cols = Helper.GetColumns(TableName);
            string PropString = "#region Properties\n";
            foreach (Column Col in Cols)
            {
                PropString += "public " + Col.Type + " " + Col.Name + " {set;get;}\n";
            }
            PropString += "#endregion Properties";
            return PropString;
        }
        public string BuildUpdate(string TableName)
        {
            List<Column> Cols = Helper.GetColumns(TableName);
            string PropString = "\nprotected void Update()\n{\n";
            PropString += "Gate.Command.CommandText = \"update " + TableName + " set \";";
            foreach (Column Col in Cols)
            {
                if (Col.Name != "ID")
                {
                    PropString += "\n if (" + Col.Name + "!= null)\n";
                    PropString += "\n {\n";
                    if (Cols.IndexOf(Col) == Cols.Count - 1)
                        PropString += "Gate.Command.CommandText += \"" + Col.Name + " = @"+Col.Name+" \";";
                    else
                        PropString += "Gate.Command.CommandText += \"" + Col.Name + " = @" + Col.Name + ",\";";
                    PropString += "\n }\n";
                }
            }
            PropString += "\n Gate.Command.CommandText += \" where ID = @ID\";";
            PropString += "\n Gate.Command.Parameters.Clear();";
            foreach (Column Col in Cols)
            {
                if (Col.Name != "ID" && Col.Type != "System.Drawing.Image")
                {
                    PropString += "\n if (" + Col.Name + "!= null)\n";
                    PropString += "\n {\n";
                    PropString += "\n Gate.Command.Parameters.AddWithValue(\"@" + Col.Name + "\", " + Col.Name + ");";
                    PropString += "\n }\n";
                }
                else if (Col.Type == "System.Drawing.Image")
                {
                    PropString += "\n if (" + Col.Name + "!= null)\n";
                    PropString += "\n {\n";
                    PropString += "\n System.IO.MemoryStream Mem = new System.IO.MemoryStream();";
                    PropString += "\n " + Col.Name + ".Save(Mem, System.Drawing.Imaging.ImageFormat.Png);";
                    PropString += "\n byte[] Data = new byte[Mem.Length];";
                    PropString += "\n Data = Mem.ToArray();";
                    PropString += "\n Gate.Command.Parameters.AddWithValue(\"@" + Col.Name + "\", Data);";
                    PropString += "\n }\n";
                }
            }
            PropString += "\nGate.Command.Parameters.AddWithValue(\"@ID\", ID);";
            PropString += "\nGate.Execute();";
            PropString += "\nGate.Close();\n";
            PropString += "}\n";
            return PropString;
        }
        public string BuildInsert(string TableName)
        {
            List<Column> Cols = Helper.GetColumns(TableName);
            string PropString = "\nprotected void Insert()\n{\n";
            PropString += "Gate.Command.CommandText = \"Insert Into " + TableName + " (\";\n";
            foreach (Column Col in Cols)
            {
                if (Col.Name != "ID")
                {
                    PropString += "\n if (" + Col.Name + "!= null)\n";
                    PropString += "\n {\n";
                    if (Cols.IndexOf(Col) == Cols.Count - 1)
                    PropString += "Gate.Command.CommandText += \"" + Col.Name + "\";";
                    else
                        PropString += "Gate.Command.CommandText += \"" + Col.Name + ",\";";
                    PropString += "\n }\n";
                }
            }
            PropString += "\n Gate.Command.CommandText += \" ) values (\";";
            foreach (Column Col in Cols)
            {
                if (Col.Name != "ID")
                {
                    PropString += "\n if (" + Col.Name + "!= null)";
                    PropString += "\n {\n";
                    if (Cols.IndexOf(Col) == Cols.Count - 1)
                        PropString += "Gate.Command.CommandText += \"@" + Col.Name + ")\";";
                    else
                        PropString += "Gate.Command.CommandText += \"@" + Col.Name + ",\";";
                    PropString += "\n }\n";
                }
            }
            PropString += "\nGate.Command.Parameters.Clear();";
            foreach (Column Col in Cols)
            {
                if (Col.Name != "ID" && Col.Type != "System.Drawing.Image")
                {
                    PropString += "\n if (" + Col.Name + "!= null)";
                    PropString += "\n {\n";
                    PropString += "\nGate.Command.Parameters.AddWithValue(\"@" + Col.Name + "\", " + Col.Name + ");";
                    PropString += "\n }\n";
                }
                else if (Col.Type == "System.Drawing.Image")
                {
                    PropString += "\n if (" + Col.Name + "!= null)";
                    PropString += "\n {\n";
                    PropString += "\nSystem.IO.MemoryStream Mem = new System.IO.MemoryStream();";
                    PropString += "\n" + Col.Name + ".Save(Mem, System.Drawing.Imaging.ImageFormat.Png);";
                    PropString += "\nbyte[] Data = new byte[Mem.Length];";
                    PropString += "\nData = Mem.ToArray();";
                    PropString += "\nGate.Command.Parameters.AddWithValue(\"@" + Col.Name + "\", Data);";
                    PropString += "\n }\n";
                }
            }
            PropString += "\nGate.Execute();";
            PropString += "\nGate.Close();";
            PropString += "}";
            return PropString;
        }
        public string BuildDelete(string TableName)
        {
            List<Column> Cols = Helper.GetColumns(TableName);
            string PropString = "\n protected void Delete()\n{\n";
            PropString += "Gate.Command.CommandText = \"Delete from " + TableName + " where ID = @ID\";";
            PropString += "\n Gate.Command.Parameters.Clear();";
            PropString += "\n Gate.Command.Parameters.AddWithValue(\"@ID\", ID);";
            PropString += "\nGate.Execute();";
            PropString += "\nGate.Close();";
            PropString += "}";
            return PropString;
        }
        public string BuildGetAll(string TableName)
        {
            List<Column> Cols = Helper.GetColumns(TableName);
            string PropString = "\n protected List<" + TableName + "> GetAll()\n{\n";
            PropString += "Gate.Command.CommandText = \"select * from " + TableName + "\";";
            PropString += "\n Gate.Command.Parameters.Clear();";
            PropString += "\n System.Data.SqlClient.SqlDataReader Reader = Gate.Execute();";
            PropString += "\n List<" + TableName + "> List = new List<" + TableName + ">();";
            PropString += "\n while (Reader!= null && Reader.Read())";
            PropString += "\n {";
            PropString += "\n " + TableName + " NewObj = new " + TableName + "();";
            #region ObjSetter
            foreach (Column Col in Cols)
            {
                PropString += "\n if (Reader[\"" + Col.Name + "\"] != null)\n{";
                switch (Col.Type)
                {
                    case "int":
                        PropString += "\n NewObj." + Col.Name + "= " + Col.Type + ".Parse(Reader[\"" + Col.Name + "\"].ToString());";
                        break;
                    case "string":
                        PropString += "\n NewObj." + Col.Name + "= Reader[\"" + Col.Name + "\"].ToString();";
                        break;
                    case "float":
                        PropString += "\n NewObj." + Col.Name + "= " + Col.Type + ".Parse(Reader[\"" + Col.Name + "\"].ToString());";
                        break;
                    case "System.Drawing.Image":
                        PropString += "byte[] ImgBytes = (byte[])Reader[\"" + Col.Name + "\"];";
                        PropString += " System.IO.MemoryStream Ms = new System.IO.MemoryStream(ImgBytes);";
                        PropString += " NewObj." + Col.Name + " = System.Drawing.Image.FromStream(Ms);";
                        break;
                    case "bool":
                        PropString += "\n NewObj." + Col.Name + "= (" + Col.Type + ")Reader[\"" + Col.Name + "\"];";
                        break;
                    case "DateTime":
                        PropString += "\n NewObj." + Col.Name + "= (" + Col.Type + ")Reader[\"" + Col.Name + "\"];";
                        break;
                    case "TimeSpan":
                        PropString += "\n NewObj." + Col.Name + "= (" + Col.Type + ")Reader[\"" + Col.Name + "\"];";
                        break;
                }
                PropString += "\n}";
            }
            PropString += "\nList.Add(NewObj);";
            PropString += "\n };";
            #endregion
            PropString += "\nGate.Close();";
            PropString += "\nreturn List;";
            PropString += "\n}";
            return PropString;
        }
        public string BuildGetByID(string TableName)
        {
            List<Column> Cols = Helper.GetColumns(TableName);
            string PropString = "\n protected " + TableName + " GetByID(int _ID)\n{\n";
            PropString += "\nGate.Command.CommandText = \"select * from " + TableName + "\";";
            PropString += "\nGate.Command.CommandText += \" Where ID = @ID \";";
            PropString += "\n Gate.Command.Parameters.Clear();";
            PropString += "\n Gate.Command.Parameters.AddWithValue(\"@ID\", _ID);";
            PropString += "\n System.Data.SqlClient.SqlDataReader Reader = Gate.Execute();";
            PropString += "\n " + TableName + " NewObj = new " + TableName + "();";
            PropString += "\n if (Reader!= null && Reader.Read())";
            PropString += "\n {";
            #region ObjSetter
            foreach (Column Col in Cols)
            {
                PropString += "\n if (Reader[\"" + Col.Name + "\"] != null)\n{";
                switch (Col.Type)
                {
                    case "int":
                        PropString += "\n NewObj." + Col.Name + "= " + Col.Type + ".Parse(Reader[\"" + Col.Name + "\"].ToString());";
                        break;
                    case "string":
                        PropString += "\n NewObj." + Col.Name + "= Reader[\"" + Col.Name + "\"].ToString();";
                        break;
                    case "float":
                        PropString += "\n NewObj." + Col.Name + "= " + Col.Type + ".Parse(Reader[\"" + Col.Name + "\"].ToString());";
                        break;
                    case "System.Drawing.Image":
                        PropString += "byte[] ImgBytes = (byte[])Reader[\"" + Col.Name + "\"];";
                        PropString += " System.IO.MemoryStream Ms = new System.IO.MemoryStream(ImgBytes);";
                        PropString += " NewObj." + Col.Name + " = System.Drawing.Image.FromStream(Ms);";
                        break;
                    case "bool":
                        PropString += "\n NewObj." + Col.Name + "= (" + Col.Type + ")Reader[\"" + Col.Name + "\"];";
                        break;
                    case "DateTime":
                        PropString += "\n NewObj." + Col.Name + "= (" + Col.Type + ")Reader[\"" + Col.Name + "\"];";
                        break;
                    case "TimeSpan":
                        PropString += "\n NewObj." + Col.Name + "= (" + Col.Type + ")Reader[\"" + Col.Name + "\"];";
                        break;
                }
                PropString += "\n}";
            }
            PropString += "\n };";
            #endregion
            PropString += "\nGate.Close();";
            PropString += "\nreturn NewObj;";
            PropString += "\n}";
            return PropString;
        }
        public string GetClassFooter(string Name)
        {
            string Footer = "\n}\n}";
            return Footer;
        }
        public string BuildClassDAL(string _TableName)
        {
            string DALClass = GetClassHeader(_TableName);
            DALClass += GetClassVariables(_TableName);
            DALClass += GetClassProperties(_TableName);
            DALClass += BuildUpdate(_TableName);
            DALClass += BuildInsert(_TableName);
            DALClass += BuildDelete(_TableName);
            DALClass += BuildGetAll(_TableName);
            DALClass += BuildGetByID(_TableName);
            DALClass += GetClassFooter(_TableName);
            return DALClass;
        }
    }
}
