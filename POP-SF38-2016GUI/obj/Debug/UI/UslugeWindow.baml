   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   &     POP_SF38_2016GUI.UI.UslugeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  UslugeWindow��5   	   $��307.818��6   $��399.674��6/    � WindowStartupLocation$ CenterScreen=�6?   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��33* �6   �� 5      $	��98* �6    � RowDefinitions 5   
   �� 5      $	��47* �6   �� 5      $
��116* �6   �� 5      $
��115* �6   .+�5   
   �� $��0��6   $��0��6   $��Usluga:��6-   $��15(�6?   $��10,10,242.6,2.2q�6M   $��2��6f   �� 5   
   -   5        $��tbUsluga��5   ;   $��0��6    �� 	MaxLength$ 80��6   $
��Auto��6.   $��22.8,10,9.6,2.2q�6K   $��1��6d   .��6t   ��5      �� 5       �� Path$ Usluga�6    �� UpdateSourceTrigger$ PropertyChanged=�6(    �� ValidationRules 5      *   $POP_SF38_2016GUI.UI.StringValidation  5      5      .��5      5      �� 5   
   $��1��6   $��0��6   $��Cena:��6-   $��15(�6=   $��10,2.8,231.6,75.2q�6K   $��2��6f   �� 5   
   -   5        $��tbCena��5   ,   $��1��6   $
��Auto��6   $��22.8,2.8,9.6,75.2q�6:   $��1��6p   ��6U   �� $
 Cena�6p   �� 5    
   -   5        $��Sacuvaj��5       $��33,46.8,242.6,21.4q�6#   $��2��6U   $��2��6b   ��5!      �� 5"       �� 
TargetType" ��6      MetroButton	 �� BasedOn#	 [  6,   .�5#      �� 
 �� Property
 � {� �� Value .  62    �� Triggers 5$      ^� 5%       ^� 
Conditions 5&      �� 5'   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ tbUsluga�� �� Value	 False6p   .0�5)      �� 
 � {� . 6:   5*      5,      5.      �� 5/   
   -   5        $��Izadji��5/      $��143.8,46.8,46.6,21.4q�6"   $��2��6\   $��1��6i   50      51      