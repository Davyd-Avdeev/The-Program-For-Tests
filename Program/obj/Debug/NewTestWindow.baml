   M S B A M L   `   `   `  ����B  >Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProgramProgram  5   	       Program.NewTestWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Program     5   	   -   5          � Title$  Новый тест��5   	   $	��480��6   $	��640��6,   $	��480��6;   $	��640��6K   $	��480��6Z   $	��640��6g    � Icon$ IconForProgram.png��6s   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ #f5f5dc��6    � Offset$ 0Q�6/   � 5      $ #42aaff��6   $ 1Q�6/   5      .+�5   
   �� -   5         ��Name$ tbxTestName��5      $
��Left=�6'   $��23��6B   $��	10,43,0,0q�6N    �� TextWrapping$
 Wrap=�6a   
�������$!��Название теста��6�   $	��Top=�6�   $	��400��6�   $	��500��6�   6�   �� 5   
   -   5         ��Name$ 	btnCreate��5      $��Создать тест��6$   $��Center=�6;   $��	0,0,0,100q�6X   $��Bottom=�6k   $	��100��6�   $��50��6�   $��75��6�   $	��150��6�      ButtonTemplate#��[  6�   $��20(�6�   $��Normal$�6�   6  �� 5   
   -   5        $ tbxPass��5      $
��Left=�6#   $��23��6>   $��	10,71,0,0q�6J   $
 Wrap=�6]   
�������$!��Введите пароль��6�   $	��Top=�6�   $	��200��6�   $	��300��6�   6�   �� 5   
   -   5        $ btnBack��5      $��
Назад��6"   $��Center=�62   $��0,0,0,40q�6O   $��Bottom=�6a   $	��100��6|   $��50��6�   $��75��6�   $	��150��6�   #��[  6�   $��20(�6�   $��Normal$�6�   6  5      5      