   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   ,    &POP_SF38_2016GUI.UI.TipNamestajaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  TipNamestajaWindow��5   	   $��236.402��6$   $��365.812��65    � WindowStartupLocation$ CenterScreen=�6E   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��158* �6   �� 5      $
��201* �6    � RowDefinitions 5   
   �� 5      $
��183* �6   �� 5      $
��137* �6   .+�5   
   �� $��0��6   $��0��6   $��Tip namestaja:��6-   $��15(�6F   $��10,25,8.2,34.4q�6T   �� 5   
   -   5        $��tbNaziv��5   ;   $��0��6   $
��Auto��6    �� 	MaxLength$ 80��6,   $��6.8,25,10.2,56.4q�6J   $��1��6d   .��6t   ��5      �� 5       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5      *   $POP_SF38_2016GUI.UI.StringValidation  5      5      .��5      5      �� 5   
   -   5        $��Sacuvaj��5      $��33,24.6,8.2,21.2q�6#   $��1��6W   ��5      �� 5       �� 
TargetType" ��6      MetroButton	 �� BasedOn#	 [  6,   .�5      �� 
 �� Property
 � {� �� Value .  62    �� Triggers 5       ^� 5!       ^� 
Conditions 5"      �� 5#   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ tbNaziv�� �� Value	 False6o   .0�5%      �� 
 � {� . 6:   5&      5(      5*      �� 5+   
   -   5        $��Izadji��5+      $��63.8,24.6,24.2,21.2q�6"   $��1��6a   $��1��6n   5-      5.      