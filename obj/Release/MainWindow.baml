   M S B A M L   `   `   `  ���� Q  MMicrobiology Receiving, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SamplesLabelingSamplesLabeling       SamplesLabeling.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:SamplesLabeling     -     � Title$  Microbiology Receiving�� � 
ResizeMode$ NoResize=�$	��400��$	��480��$��24(� � Icon$ .\app_icon.ico��.��� $��Center=�$��Center=� � ColumnDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��20 �.+��� $��1��$��1��$��28(�$��Microbiology Receiving��$��2��$��0,0,0,24q��� $��1��$��2��$
��Area��$��SemiBold"��� -    ��Name$ areaList��$��2��$��2��.@��� .��A�� .��B�� .��C�� .��D�� $��1��$��3��$��Specimen��$��SemiBold"��� -   $ specimenList��$��2��$��3���� $��1��$��4��$��ID��$��SemiBold"�$��2���� -    ��Name$ sampleID��$��2��$��4���� $��1��$��5��$
��Date��$��SemiBold"�(  "System.Windows.Controls.DatePicker  -     Name$ 
sampleDate��$��2��$��5���� -    ��Name$ printButton��$��Print Stickers��$��1��$��6��$��	0,10,0,10q�$��2���� -   	 ��Name$	 updateSampleIdBox��$��Update Sample ID��$��14(�$��1��$��7���� -   
 ��Name$
 	aboutLink��$��About�� � Cursor$
 Hand��
����  �$��	Underline{�$��1��$��8��$��0,12,0,0q�$��16(�