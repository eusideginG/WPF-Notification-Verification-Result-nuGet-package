   M S B A M L   `   `   `  ����D  @UIMessage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:UIMessage	UIMessage  5   	       UIMessage.NotifyPopUp   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:UIMessage     5   	   -   5          � Title$  PopUp��5	   	   $	��100��6   $	��400��6$    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency$
 True��5   	    � 	Resources 5         CloseButton �� 
TargetType �� 	Resources �� Property �� Value	 �� Triggers
 P� Property P� Value �� 
TargetType��%�  &	        �� 5   
   " ��6$    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 20��65   �� 5       � ��$ 40��6.   �� 5       � ��$ 40��6/   �� 5       � ��
 ���� 64   �� 5       � ��$ 0q�68   �� 5       � ��
 ���� 63   5      5      	 5      P� 5      
 �@J�IsMouseOver$
 True��61   . �5      ��  �@�Cursor$
 Hand��6/   5      .�5      ��  � �� 5       �� 5!      " ��6&   .R�5"      �� 
������ ._�5#      �� 5$      5%      5'      �� 5(       � ��$	 Top=�62   �� 5)       � ��$ Right=�64   5*      5+      .��5,      ��  �� CornerRadius$ 20��66   ��6   �� *NotificationColor+._�5-   
   �  � RowDefinitions 5.      �� 5/      $	��60* �6    �� 50      $	��40* �6     � ColumnDefinitions 52      �� 53      $	��15* �6#   �� 54      $	��70* �6#   �� 55      $	��15* �6#   .+�58      �� $��50��6   $��50��6   $��8,8,0,0q�6+   $
��Left=�6<   $	��Top=�6W   ��6o   �� *NotificationIcon+�� 59      $��1��6   $��0,8,0,0q�6(   $
��Bold"�6\   $��24(�6n   ��69   �� *NotificationTitle+6n   �� 5:      -   5        $��2��5:      #��[  6%   .��5;      �� $��2��6   $��20��6(   $��20��63   $��icons/close.png��6?   5<      �� 5=      $��1��6   $��3��6%   $��8,0,8,8q�69   $��16(�6o   $��DemiBold"�6}   $��Center=�6�   $
��Wrap=�6�   ��6J   �� *NotificationMessage+6�   5>      5?      5@      