   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   
���   �  � Title$  
MainWindow��5	   	   $	��800��6   $
��1500��6)    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5      � ��5   
   �� 5       �� ImageSource$R L/Client;component/abstract-medical-wallpaper-template-design_53876-61802.jpg��6   .+�5   
   �� 
������ 
���   �$��2q�6>   
���   �$
��Left=�6�   $��
120,16,0,0q�6�   $	��Top=�6�   $��94��6�   $��20(�6  $��65��6  $
��Bold"�6  y�6f   �� *AdminVisibility+��6�   �� *AddUserCommand+.��5      ��  �� TextAlignment$ Center=�6   $
��Wrap=�6/   
ADD USER6N   5      �� 5   
   
������ 
���   �$��2q�6>   
���   �$
��Left=�6�   $��	11,16,0,0q�6�   $	��Top=�6�   $��94��6�   $��20(�6�   $��65��6�   $
��Bold"�6�   ��6f   �� *ChangeInfoCommand+.��5      �� $ Center=�6   $
��Wrap=�6/   CHANGE INFO6Q   5      �� 5   
   $��LOGOUT��6   
������ 
���   �$��2q�6O   
���   �$
��Left=�6�   $��1378,16,0,0q�6�   $	��Top=�6�   $	��106��6�   $��20(�6�   $��58��6�   $
��Bold"�6  ��6v   �� *LogoutCommand+6  �� 5   
   
������ 
���   �$��2q�6?   
���   �$��1125,185,0,0q�6�   $	��Top=�6�   $��20(�6�   $��56��6�   $
��Bold"�6�   $
��Left=�6�   $	��160��6  ��6g   �� *AddAppointmentCommand+.��5      �� $ Center=�6   $
��Wrap=�6/   ADD APPOINTMENT6U   5      �� 5   
   
������ 
���   �$��2q�6>   
���   �$��1125,246,208.6,0q�6�   $	��Top=�6�   $��20(�6�   $��56��6�   $
��Bold"�6�   ��6f   �� *ChangeAppointmentCommand+.��5      �� $ Center=�6   $
��Wrap=�6/   CHANGE APPOINTMENT6X   5      �� 5   
   
������ 
���   �$��2q�6?   
���   �$��1291,185,0,0q�6�   $	��Top=�6�   $��20(�6�   $��56��6�   $
��Bold"�6�   $
��Left=�6�   $	��159��6	  ��6g   �� *DeleteAppointmentCommand+.��5      �� $ Center=�6   $
��Wrap=�6/   DELETE APPOINTMENT6X   5      �� 5    
   
������ 
���   �$��2q�6?   
���   �$��1291,246,0,0q�6�   $	��Top=�6�   $��20(�6�   $��56��6�   $
��Bold"�6�   $
��Left=�6�   $	��159��6  ��6g   �� *CloneAppointmentCommand+.��5!      �� $ Center=�6   $
��Wrap=�6/   CLONE APPOINTMENT6W   5"      �� 5#   
   $��SEARCH��6   
������ 
���   �$��2q�6O   
���   �$
��Left=�6�   $��
745,16,0,0q�6�   $	��Top=�6�   $	��129��6�   $��20(�6�   $��34��6�   $
��Bold"�6  ��6w   �� *SearchCommand+6  �� 5$   
   $��REFRESH��6   
������ 
���   �$��2q�6P   
���   �$
��Left=�6�   $��
745,65,0,0q�6�   $	��Top=�6�   $	��129��6�   $��20(�6�   $��34��6�   $
��Bold"�6   J� RenderTransformOrigin$ 0.518,0.532&�6  ��6x   �� *RefreshCommand+6  �� 5%   
   
������ 
���   �$��2q�6?   
���   �$��1125,454,0,0q�6�   $	��Top=�6�   $��20(�6�   $��56��6�   $
��Bold"�6�   $
��Left=�6  $	��160��6,  y�6f   �� *DoctorVisibility+��6�   �� *AddDiagnosisCommand+.��5&      �� $ Center=�6   $
��Wrap=�6/   ADD DIAGNOSIS6S   5'      �� 5(   
   
������ 
���   �$��2q�6?   
���   �$��1291,454,0,0q�6�   $	��Top=�6�   $��20(�6�   $��56��6�   $
��Bold"�6  $
��Left=�6  $	��159��6/  y�6f   �� *DoctorVisibility+��6�   �� *ChangeDiagnosisCommand+.��5)      �� $ Center=�6   $
��Wrap=�6/   CHANGE DIAGNOSIS6V   5*      �� 5+   
   $
��UNDO��6   
������ 
���   �$��2q�6M   
���   �$
��Left=�6�   $��1125,327,0,0q�6�   $	��Top=�6�   $	��160��6�   $��20(�6�   $��34��6�   $
��Bold"�6  ��6u   �� *UndoCommand+6  �� 5,   
   $
��REDO��6   
������ 
���   �$��2q�6M   
���   �$
��Left=�6�   $��1291,328,0,0q�6�   $	��Top=�6�   $	��159��6�   $��20(�6�   $��33��6�   $
��Bold"�6  ��6u   �� *RedoCommand+6  �� 5.   
   -   5        $��Theater��5.      
������ $��
11,127,0,0q�6=   $	��632��6R   $	��Top=�6_   $
��Left=�6w   $
��1095��6�   .@�5/      �� $��Appointments��6   
�������
���   �.��50      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridAppointments��50      $
��Left=�52   A   $��-5,3,0,0q�6\      CanUserResizeRows .  $   HorizontalScrollBarVisibility$
 Auto=�6�   $	��Top=�6�   $	��598��6�   $
��1094��6�   $��Khmer UI)�6�   $��14(�6�   
���   �	   GridLinesVisibility$
	 None=�53   &   
������ $��3q�6[   
   
IsReadOnly
 .    SelectionMode$ Single=�6�      AutoGenerateColumns .  ��51      �� *Appointments+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 52      �� *SelectedAppointment+��53   �   Z�    Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Doctor��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Doctor+  58      $ Patient��6-   $	 150 6>    6J   �� *	Patient+  59      $ AppointmentTime��6-   $	 200 6F    6R   �� *AppointmentTime+  5:      $ 	Diagnosis��6-   $ * 6@    6J   �� *	Diagnosis+5<      5=      �� 5>      $��Logging��6   
�������
���   �.��5?        -   5        $ dataGridLog��5?      $
��Left=�5A      $��-5,3,0,0q�6/    .  $
 Auto=�6[   $	��Top=�6�   $	��598��6�   $
��1093��6�   $��Khmer UI)�6�   $��14(�6�   $
	 None=�5B      
������ $��3q�6I   
 . $ Single=�6�    .  $ 0.505,0.496&�6�   ��5@      �� *	Loggers+$ PropertyChanged=���5B   q   Z�  5E        5F      $
 Type��6-   $	 150 6;    6G   �� *Type+  5G      $
 Text��6-   $	 860 6;    6G   �� *Text+5I      5K      5L      (  "System.Windows.Controls.DatePicker  5M   
   $��593,36,771.6,0q�6:   $��25��6R   $	��Top=�6^      SelectedDate 6   �� *DateContent+6^   �� 5O   
   
������ $��Segoe UI)�5Q   '   
�������$
��Left=�6R   $��
593,72,0,0q�6m   $	��129��6�   $��25��6�   $ 0.475,0.491&�6�   $	��Top=�6�   ��5O      �� *DateConditionContent+ 5P      �� *SelectedDateContent+5Q   �   �� 5R   
   
���   �$��Center=�6#   $��Date Search��6G   $��
593,12,0,0q�6]   $��24��6q   $	��Top=�6}   $
��Left=�6�   $	��129��6�   6�   5S      5T      