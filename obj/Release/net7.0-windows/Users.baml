   M S B A M L   `   `   `  ���� R  NPatientManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PatientManagementSystemPatientManagementSystem  #    PatientManagementSystem.Users   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:PatientManagementSystem     .��� .+�� -     �Name$  gridSideBar��$y�Visible=� � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0�����	#FF172554$��	0,0,100,0q�.+��� $
��Left=���Z� ��Z� .����  �� Orientation$ 
Horizontal=�.+��� $$��/assets/images/ezaret-logo.png��$��38��$��40��$��1,0,10,0q��� $��ADMIN��$��Center=�$��Arial)�$��11(����	#FFF4F4F5$��53���� $��0,10,0,0q�$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+��� $6��0/assets/images/baseline_dashboard_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��	Dashboard��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $<��6/assets/images/baseline_personal_injury_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Patients��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q����	#FF1E40AF$
��Left=�$	��100��.���� $ 
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
   $  gridDataTable��$��2��$��	100,0,0,0q����	#FF1E293B$y�Visible=�.+��� $��Users��$��Center=�$	��Top=����	#FFF4F4F5$��30(�$��91��$
��Bold"��� $
��Auto=�$
��Auto=�.��&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��10,120,0,60q����� *users+   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$ 25����  � ��$ Black"���  �@ SeparatorBrush
 �������  � �� �� .R��� $
��20,0q����� �� -   $��Refresh��$
��Left=�$��	18,80,0,0q�$	��Top=����	#FF052E16
�������$	��101���� -   $��searchTextBox��$��Right=�$��
0,81,104,0q� �� TextWrapping$
 Wrap=�$��Search for item here....��$	��Top=�$	��300���� -   $��Search��$��Right=�$	��Top=�$��74��$��	0,80,10,0q����	#FF052E16
�������