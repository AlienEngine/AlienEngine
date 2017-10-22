﻿using System;
using System.Collections.Generic;

namespace AlienEngine.UI
{
    public class Console : UIContainer
    {
        private TextBox textBox;
        private TextInput textEntry;

        public Console(BMFont font)
            : base(new Point2i(0, 0), new Sizei(500, 300), "Console" + UserInterface.GetUniqueElementID())
        {
            textBox = new TextBox(font, null);
            textBox.RelativeTo = Corner.TopLeft;
            textBox.BackgroundColor = new Color4(0, 0, 0, 0.5f);
            textBox.AllowScrollBar = true;
            this.AddElement(textBox);

            textEntry = new TextInput(font);
            textEntry.RelativeTo = Corner.BottomLeft;
            textEntry.BackgroundColor = new Color4(0, 0, 0, 0.7f);
            this.AddElement(textEntry);

            textEntry.OnCarriageReturn = new TextInput.OnTextEvent(ExecuteCommand);
        }

        public override void OnResize()
        {
            base.OnResize();

            textBox.Size = new Sizei(Size.X, Size.Y - textBox.Font.Height);
            textEntry.Size = new Sizei(Size.X, textBox.Font.Height);
        }

        public delegate void OnCommand(string args);

        public Dictionary<string, OnCommand> commands = new Dictionary<string, OnCommand>();

        private void ExecuteCommand(TextInput entry, string command)
        {
            if (command.Length == 0) return;
            entry.Clear();

            textBox.Write(Color3.White, "> ");
            textBox.WriteLine(new Color3(0, 0.6f, 0.9f), command);

            try
            {
                if (command.Contains(" "))
                {
                    int i = command.IndexOf(" ");
                    string opcode = command.Substring(0, i);

                    if (commands.ContainsKey(opcode)) commands[opcode](command.Substring(i + 1));
                    else textBox.WriteLine(Color3.Red, "Unknown command");
                }
                else
                {
                    if (commands.ContainsKey(command)) commands[command]("");
                    else textBox.WriteLine(Color3.Red, "Unknown command");
                }
            }
            catch (Exception e)
            {
                textBox.WriteLine(Color3.Red, "Exception while running command.  " + e.Message);
            }
        }

        #region Write Methods
        public void Write(string message)
        {
            Write(Color3.White, message);
        }

        public void WriteLine(string message)
        {
            textBox.WriteLine(message);
        }

        public void Write(Color3 color, string message)
        {
            textBox.Write(color, message);
        }

        public void WriteLine(Color3 color, string message)
        {
            textBox.WriteLine(color, message);
        }

        public void Write(Color3 color, string message, BMFont customFont)
        {
            textBox.Write(color, message, customFont);
        }

        public void WriteLine(Color3 color, string message, BMFont customFont)
        {
            textBox.WriteLine(color, message, customFont);
        }

        public void Clear()
        {
            textBox.Clear();
        }
        #endregion
    }
}
