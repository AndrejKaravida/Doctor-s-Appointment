   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	        Client.Views.AddChangeUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	   
���   �  � Title$  AddChangeUser��5   	   $��813.966��6   $��500.33��60    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   .��5	      � ��5
   
   �� 5       �� ImageSource$R L/Client;component/abstract-medical-wallpaper-template-design_53876-61802.jpg��6   .+�5   
   �� 
���   �$��Center=�6#   $��10,10,9.6,0q�6h   $	��Top=�6}   $��24(�6�   $
��Bold"�6�   ��6G   �� *TitleContent+6�   �� 5   
   
���   �$��Center=�6#   $��Username��6G   $
��Left=�6Z   $��	10,90,0,0q�6u   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $	��474��6�   �� 5   
   
���   �
������ 
���   �$��2q�6R   $
��Left=�6f   $��44��6�   $��160,137,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��173��6�   $��24(�6�   ��6�   �� *User.Username+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6y   $��
10,186,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� *!User.ValidationErrors[Username]+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6g   $��
10,186,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� *CheckUsername+6�   �� 5   
   $��Center=�6   
���   �$��Password��6G   $
��Left=�6Z   $��
10,217,0,0q�6u   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $	��474��6�   �� 5   
   
���   �
������ 
���   �$��2q�6R   $
��Left=�6f   $��44��6�   $��160,264,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��173��6�   $��24(�6�   ��6�   �� *User.Password+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6y   $��
10,313,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� *!User.ValidationErrors[Password]+6�   �� 5   
   $��Center=�6   
���   �$��
First Name��6G   $��
10,344,0,0q�6\   $	��Top=�6p   $��24(�6�   $
��Bold"�6�   $
��Left=�6�   $	��474��6�   �� 5   
   
���   �
������ 
���   �$��2q�6R   $
��Left=�6f   $��44��6�   $��160,391,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��173��6�   $��24(�6�   ��6�   �� *User.FirstName+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6z   $��
10,440,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� *" User.ValidationErrors[FirstName]+6�   �� 5   
   $��Center=�6   
���   �$��	Last Name��6G   $
��Left=�6[   $��
10,471,0,0q�6v   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $	��474��6�   �� 5   
   
���   �
������ 
���   �$��2q�6R   $
��Left=�6f   $��44��6�   $��160,518,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��173��6�   $��24(�6�   ��6�   �� *User.LastName+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6n   $��
10,567,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� *User.Black[LastName]+6�   �� 5   
   $��Segoe UI)�6   
���   �$��Doctor��6c   $
��Left=�6�   $��45��6�   $��198,598,0,0q�6�   $	��Top=�6�   $	��135��6  $��24(�6  
�������
�������y�6)   �� *CheckBoxVisible+ d� 	IsChecked 6t   �� *
IsDoctor+ �� UpdateSourceTrigger$ PropertyChanged=�6:  �� 5!   
   
���   �
������ 
���   �$��2q�6Q   $��160,694,160.6,0q�6�   $	��Top=�6�   $��36(�6�   $��61��6�   $
��Bold"�6�   ��6e   �� *TitleContent+��6�   �� *AddChangeUserCommand+6�   5#      5$      