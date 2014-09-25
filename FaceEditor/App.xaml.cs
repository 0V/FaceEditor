﻿// Copyright (c) 2009 Daniel Grunwald
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace AvalonEdit.Sample
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
        {
            AppDomain.CurrentDomain.UnhandledException += ((_sender, _e) =>
                ShowErrorMessage((Exception)_e.ExceptionObject));
			InitializeComponent();
		}

        public static void ShowErrorMessage(Exception e)
        {
            MessageBox.Show("エラーが発生しました:\n" + e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show("エラーが発生しました:\n" + message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
	}
}