   M S B A M L   `   `   `  ���� R  NPatientManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PatientManagementSystemPatientManagementSystem  %    PatientManagementSystem.Patient   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:PatientManagementSystem     .��� .+�� -     �Name$  sideBarPatient�� � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0�����	#FF172554$��	0,0,100,0q�.+��� $
��Left=���Z� ��Z� .����  �� Orientation$ 
Horizontal=�.+��� $$��/assets/images/ezaret-logo.png��$��38��$��40��$��1,0,10,0q��� $��ADMIN��$��Center=�$��Arial)�$��11(����	#FFF4F4F5$��53���� $��0,10,0,0q�$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+��� $6��0/assets/images/baseline_dashboard_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��	Dashboard��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q����	#FF1E40AF$
��Left=�$	��100��.���� $ 
Horizontal=�.+��� $<��6/assets/images/baseline_personal_injury_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Patients��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $3��-/assets/images/baseline_people_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Users��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $8��2/assets/images/baseline_description_white_24dp.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Lab Test��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $$��/assets/images/pill-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��	Drug Test��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $)��#/assets/images/test-tube-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Herma��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$��99����Z� ��Z� .���� $ 
Horizontal=�.+��� $-��'/assets/images/radiology-box-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Radio��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $-��'/assets/images/emoticon-poop-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��	Fecalysis��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -	   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $;��5/assets/images/baseline_account_circle_white_24dp.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Account��$��Center=�$��Arial)�$��11(����	#FFF4F4F5� -
   $  gridPatient��$��2��$��	100,0,0,0q����	#FF1E293B$y�Visible=�.+��� $��Manage patients��$��Center=�$	��Top=����	#FFF4F4F5$��30(�$	��244��$
��Bold"�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��10,120,0,60q����� *users+   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$ 25����  � ��$ Black"���  �@ SeparatorBrush
 �������  � �� �� .R��� $
��20,0q����� �� -   $��Add new��$
��Left=�$��	10,80,0,0q�$	��Top=����	#FF052E16���	#FF86EFAC$	��101���� -   $��Refresh��$
��Left=�$��
116,80,0,0q�$	��Top=����	#FF052E16
�������$	��101���� -   $��searchTextBox��$��Right=�$��
0,81,104,0q� �� TextWrapping$
 Wrap=�$��Search for item here....��$	��Top=�$	��300���� -   $��Search��$��Right=�$	��Top=�$��74��$��	0,80,10,0q����	#FF052E16
�������� -   $  gridAddPatient��
������ $	��800��$	��800��$y�	Collapsed=�.+��� $��REGISTER PATIENT��$��Center=�$��50(����	#FFF3E9E9$��
0,10,0,723q�$��Century Gothic)�$
��Bold"��� $��Firstname                ��$��30(�$
��Left=����	#FFF3E9E9$��20,123,0,527q�$	��155���� -   	 ��Name$	 txtFirstname��$
��Left=�$��
20,182,0,0q�$
 Wrap=�$	��Top=�$	��217��$��30(����	#FF075985�� $��
Middlename��$��30(�$
��Left=����	#FFF3E9E9$��286,123,0,527q�$	��185���� -   $	 txtMiddlename��$��Center=�$��	0,182,0,0q�$
 Wrap=�$	��Top=�$	��228��$��30(����	#FF075985�� $��Lastname��$��30(�$
��Left=����	#FFF3E9E9$��550,123,0,527q�$	��135���� -   $	 txtLastname��$
��Left=�$��550,182,0,0q�$
 Wrap=�$	��Top=�$	��227��$��30(����	#FF075985�� $��Email��$��30(�$
��Left=����	#FFF3E9E9$��20,267,0,383q�$	��155���� -   $	 txtEmail��$
��Left=�$��
20,322,0,0q�$
 Wrap=�$	��Top=�$	��494��$��30(����	#FF075985�� $	��Age��$��30(�$
��Left=����	#FFF3E9E9$��550,267,0,383q�$	��155���� -   $	 txtAge��$
��Left=�$��550,322,0,0q�$
 Wrap=�$	��Top=�$	��227��$��30(����	#FF075985�� $��Birthday��$��30(�$
��Left=����	#FFF3E9E9$��20,415,0,235q�$	��155��(  "System.Windows.Controls.DatePicker  -   
  Name$
 	birthDate��$
��Left=�$��
20,475,0,0q�$	��Top=�$	��380��$��50���� $��Address��$��30(�$
��Left=����	#FFF3E9E9$��421,415,0,235q�$	��155���� -   $	 
txtAddress��$
��Left=�$��421,475,0,0q�$
 Wrap=�$	��Top=�$	��356��$��30(����	#FF075985�� $��Password��$��30(�$
��Left=����	#FFF3E9E9$��20,554,0,192q�$	��155��G� -   $��txtPassword��$
��Left=�$��
20,612,0,0q�$	��Top=�$	��757��$��30(����	#FF075985�� -   $
��SAVE��$
��Left=�$��
20,700,0,0q�$	��Top=����	#FF052E16
�������$	��478��$��57���� -   $��CANCEL��$
��Left=�$��518,702,0,0q�$	��Top=�
�������
�������$	��259��$��57��