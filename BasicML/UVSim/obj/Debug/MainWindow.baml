   M S B A M L   `   `   `  ����@  <UVSim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UVSimUVSim  5   	       UVSim.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:UVSim     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   e aDevExpress.Xpf.RichEdit.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.RichEdit.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aEdxre6http://schemas.devexpress.com/winfx/2008/xaml/richedit    5   	     � Title$  UVSIM��5
   	   $	��600��6   $	��800��6$   $��	Helvetica)�60   $
��14px(�6G   $
��Bold"�5   	   $	��640��6   $	��480��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��22px(�6   $��0��6    $��0��60   .��6=   	Program6F   �� 5   
   $
��22px(�6   $��1��6    $��0��60   .��6=   	Console6F   -  'DevExpress.Xpf.RichEdit.RichEditControl  5   
   -   5          Name$ 	reProgram��5      $��0��62   $��1��6B   $��3,3,3,3q�6O      
ShowBorder .    ShowHoverMenu .     ShowReviewingPane .  5   j     5   
   -   5        $ 	reConsole��5      $��1��62   $��1��6B   $��3,3,3,3q�6O    .  .   .     ReadOnly . 5   y   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��2��6B   .+�5      &   DevExpress.Xpf.Core.SimpleButton  -   5        	  Name$	 
btnExecute��5      $��10,5,3,5q�62   .��6]   	Execute6f     5      -   5        $	 
btnCompile��5      $��3,5,3,5q�62   .��6\   	Compile6e     5      -   5        $	 btnLoad��5      $��3,5,3,5q�6/   .��6V   Load from file6f     5       -   5        $	 btnLoadMultiple��5       $��3,5,3,5q�67   .��6f   Load Multiple files6{     5!      -   5        $	 btnSave��5!      $��3,5,3,5q�6/   .��6V   Save to file6d   5"      5#      5$      