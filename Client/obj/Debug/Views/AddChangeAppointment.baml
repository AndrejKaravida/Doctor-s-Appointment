   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	   '    !Client.Views.AddChangeAppointment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	   
���   �  � Title$  AddChangeAppointment��5   	   $��813.966��6'   $��500.33��68    � 
ResizeMode$ NoResize=�6G    � WindowStartupLocation$ CenterScreen=�6]   .��5	      � ��5
   
   �� 5       �� ImageSource$R L/Client;component/abstract-medical-wallpaper-template-design_53876-61802.jpg��6   .+�5   
   �� 
���   �$��Center=�6#   $��10,10,9.6,0q�6h   $	��Top=�6}   $��24(�6�   $
��Bold"�6�   ��6G   �� *TitleContent+6�   �� 5   
   
���   �$��Center=�6#   $��Doctor��6G   $
��Left=�6X   $��
10,166,0,0q�6s   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $	��474��6�   �� 5   
   $
��Left=�6`   $��160,212,0,0q�6{   $	��Top=�6�   $	��173��6�   $��42��6�   ���	#FF373737$��25(�6�   
���   ���6   �� *	Doctors+ �� SelectedItem 63   �� *Appointment.Doctor+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6~   $��
10,262,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� *&$Appointment.ValidationErrors[Doctor]+6�   �� 5   
   $��Center=�6   
���   �$
��Date��6G   $
��Left=�6V   $��
10,293,0,0q�6q   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $	��474��6�   (  "System.Windows.Controls.DatePicker  5   
   $��24(�6   $
��Left=�6Y   $��160,340,0,0q�6t   $	��Top=�6�   $	��173��6�   $��42��6�      SelectedDate 6#   �� *Appointment.AppointmentTime+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6�   $��
10,387,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��64   �� */-Appointment.ValidationErrors[AppointmentTime]+6�   �� 5   
   $��Center=�6   
���   �$
��Time��6H   $��
10,391,0,0q�6W   $	��Top=�6k   $��24(�6�   $
��Bold"�6�   $
��Left=�6�   $	��474��6�   �� 5   
   $
��Left=�6Q   $��160,438,0,0q�6l   $	��Top=�6�   $	��173��6�   $��42��6�   ���	#FF373737$��25(�6�   
���   ���6   �� *Hours+ 62   �� *Hour+6�   �� 5   
   $��Center=�6   
���  ��$
��Left=�6�   $��
10,487,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   ��65   �� */-Appointment.ValidationErrors[AppointmentTime]+6�   �� 5   
   $��Center=�66   
���   �$��Patient��6m   $��
10,518,0,0q�6   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $
��Left=�6�   $	��474��6�   y�6   �� *PatientVisible+6�   �� 5   
   $
��Left=�6�   $��160,565,0,0q�6�   $	��Top=�6�   $	��173��6�   $��42��6�   ���	#FF373737$��25(�6�   
���   �y�6   �� *PatientVisible+��69   �� *
Patients+ 6Z   �� *Appointment.Patient+6  �� 5   
   $��Center=�66   
���  ��$
��Left=�6�   $��
10,614,0,0q�6�   $	��Top=�6�   $	��474��6�   $��26��6�   y�6   �� *PatientVisible+��6Z   �� *'%Appointment.ValidationErrors[Patient]+6�   �� 5   
   
���   �
������ 
���   �$��2q�6Q   $��160,694,160.6,0q�6�   $	��Top=�6�   $��36(�6�   $��61��6�   $
��Bold"�6  ��6e   �� *TitleContent+��6�   �� *AddChangeAppointmentCommand+6  5!      5"      