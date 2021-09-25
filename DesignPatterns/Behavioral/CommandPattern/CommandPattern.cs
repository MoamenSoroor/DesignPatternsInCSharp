using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.CommandPattern
{
	class CommandPattern
	{

		public static void Test()
		{
			Editor editor = new Editor();

			ICommand append1 = new AppendTextCommand(editor, "hello");
			ICommand append2 = new AppendTextCommand(editor, "World");
			ICommand append3 = new AppendTextCommand(editor, ",moamen");

			EditorCommandManager manger = new EditorCommandManager(editor);

			manger.Invoke(append1);
			manger.Invoke(append2);
			manger.Invoke(append3);

			manger.Undo();
			manger.Undo();
			manger.Undo();
			
			Console.ReadLine();


		}
		public static void Test0()
		{
			Editor editor = new Editor();

			ICommand append1 = new AppendTextCommand(editor, "hello");
			ICommand append2 = new AppendTextCommand(editor, "World");
			ICommand append3 = new AppendTextCommand(editor, ",moamen");

			append1.Execute();
			Console.WriteLine(editor.Text);
			Console.ReadLine();

			append2.Execute();
			Console.WriteLine(editor.Text);
			Console.ReadLine();

			append3.Execute();
			Console.WriteLine(editor.Text);
			Console.ReadLine();


			append3.Undo();
			Console.WriteLine(editor.Text);
			Console.ReadLine();

			append2.Undo();
			Console.WriteLine(editor.Text);
			Console.ReadLine();

			append1.Undo();
			Console.WriteLine(editor.Text);
			Console.ReadLine();

		}
	}





	public class Editor
	{
		public StringBuilder Text { get; } = new StringBuilder();

		public override string ToString()
		{
			return Text.ToString();
		}


	}


	public class EditorCommandManager
	{
		Editor editor;

		public EditorCommandManager(Editor editor)
		{
			this.editor = editor;
		}


		Stack<ICommand> commands = new Stack<ICommand>();

		public void Invoke(ICommand command)
		{
			commands.Push(command);
			command.Execute();
			Console.WriteLine(editor.Text);
			Console.ReadLine();
		}


		public void Undo()
		{
			
			var invoke =  commands.Pop();
			invoke.Undo();
			Console.WriteLine(editor.Text);
			Console.ReadLine();
		}


		public void UndoAll()
		{
			
			while (commands.Any())
			{
				Undo();
			}


			
			Console.WriteLine(editor.Text);
			Console.ReadLine();
		}


	}




	public class EditorBatchCommandManager
	{
		Editor editor;

		public EditorBatchCommandManager(Editor editor)
		{
			this.editor = editor;
		}


		List<ICommand> commands = new List<ICommand>();

		public void Add(ICommand command)
		{
			commands.Add(command);
		}

		public void ExecuteAll()
		{
			foreach (var item in commands)
			{
				item.Execute();
			}
		}

		public void UndoAll()
		{
			foreach (var item in commands.Reverse<ICommand>())
			{
				item.Undo();
			}
		}


	}




	public interface ICommand
	{
		void Execute();
		void Undo();
	}



	class AppendTextCommand: ICommand
	{
		private readonly Editor editor;
		private readonly string text;

		public AppendTextCommand(Editor editor, string text)
		{
			this.editor = editor;
			this.text = text;
		}
		public void Execute()
		{
			editor.Text.Append(text);
		}

		public void Undo()
		{
			editor.Text.Remove(editor.Text.Length - text.Length, text.Length);
		}


	}

	// abc

	class RemoveTextCommand : ICommand
	{
		private readonly Editor editor;
		private readonly string text;

		public RemoveTextCommand(Editor editor, string text)
		{
			this.editor = editor;
			this.text = text;
		}
		public void Execute()
		{

			editor.Text.Remove(editor.Text.Length - text.Length, text.Length);

		}

		public void Undo()
		{

			editor.Text.Append(text);
		}


	}


}