/*
 * Created by SharpDevelop.
 * User: tiago.lucas
 * Date: 9/2/2019
 * Time: 12:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace Minha_aplicacao
{
	class Program
	{
		//main
		public static void Main(string[] args)
		{
			string[] a = {"Digite o login: ", "Digite a senha: "};
			string[] b = new string[2];
			for(int i=0;i<a.Length;i++){
				Console.WriteLine(a[i]);
				b[i] = Console.ReadLine();
			}
			OdbcConnection s = connect(b);			
			
			if(s.State.Equals(System.Data.ConnectionState.Open)){
				selectAll(s);
				selectSpecified("tiago",s);
				selectCollection("tiago",s);
			}
			
			var names = new List<string>{"<name>", "Ana", "Felipe"};
			var n = new List<string>();
			foreach(var name in names){
				Console.WriteLine("Hello {0}!",name.ToUpper());
			}
			Console.ReadKey(true);
		}
		
		//select all
		private static void selectAll(OdbcConnection odbcConnection){
			try{
				OdbcCommand odbcCommand = new OdbcCommand("select * from escola1", odbcConnection);
				OdbcDataReader reader = odbcCommand.ExecuteReader();								
				if(reader!=null)printSearch(reader);				
			}catch(Exception e){
				Console.WriteLine("{0}",e.ToString());				
			}
		}
		
		//print dataReader
		private static void printSearch(OdbcDataReader reader){
			Console.WriteLine();
			for(int i=0;i<43;i++){Console.Write("=");}
			Console.WriteLine();
			Console.WriteLine("|{0,-20}|{1,-20}|","RGM","Nome");
			while(reader.Read()){
				Console.WriteLine("|{0,20}|{1,20}|",reader.GetString(0),reader.GetString(1));
			}				
			for(int i=0;i<43;i++){Console.Write("=");}
			for(int i=0;i<2;i++){Console.WriteLine();}
		}
		
		//select nome especifico
		private static void selectSpecified(string i, OdbcConnection odbc){
			try{
				OdbcCommand odbcCommand = new OdbcCommand("select * from escola1 where nome=?",odbc);
				odbcCommand.Parameters.AddWithValue("?","tiago");
				OdbcDataReader d = odbcCommand.ExecuteReader();
				printSearch(d);
			}catch(Exception e){
				Console.WriteLine("{0}", e.ToString());
			}
		}
		
		//select nome especifico collection
		private static void selectCollection(string i, OdbcConnection odbc){
			try{
				OdbcCommand odbcCommand = new OdbcCommand("select * from escola1 where nome=? and rgm=?",odbc);
				odbcCommand.Parameters.AddWithValue("?",i);
				odbcCommand.Parameters.AddWithValue("?","1234");
				OdbcDataReader d = odbcCommand.ExecuteReader();
				printSearch(d);
			}catch(Exception e){
				Console.WriteLine("{0}", e.ToString());
			}
		}
		
		//connect
		private static OdbcConnection connect(string[] b){
			OdbcConnection s = null;
			try{
				string a = "DRIVER={MySQL ODBC 5.1 Driver};SERVER=localhost;DATABASE=tiago;UID="+b[0]+";PASSWORD="+b[1]+";OPTION=3;";
				s = new OdbcConnection(a);				
				s.Open();
				
			}catch(Exception e){
				//Console.WriteLine("Error: {0}",e.ToString());
				Console.WriteLine("Acesso negado!");
			}
			return s!=null?s:null;
		}
		private enum msg{BOLO,	Banana};
	}
}