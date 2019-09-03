/*
 * Created by SharpDevelop.
 * User: tiago.lucas
 * Date: 9/2/2019
 * Time: 11:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Minha_Aplicacao_DB
{
	public class Program 
	{
		public static void Main(string[] args)
		{
			var names = new List<string>{"<name>", "Ana", "Felipe"};			
			foreach(var name in names){
				Console.WriteLine($"Hello {name.ToUpper()}!");
			}
			Console.ReadKey(true);
		}
	}
}