   M S B A M L   `   `   `  ���� R  NPatientManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PatientManagementSystemPatientManagementSystem  '    !PatientManagementSystem.Fecalysis   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:PatientManagementSystem     $	��943��.��� .+�� -     �Name$  gridSideBar��$y�Visible=� � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0�����	#FF172554$��	0,0,100,0q�.+��� $
��Left=���Z� ��Z� .����  �� Orientation$ 
Horizontal=�.+��� $$��/assets/images/ezaret-logo.png��$��38��$��40��$��1,0,10,0q��� $��ADMIN��$��Center=�$��Arial)�$��11(����	#FFF4F4F5$��53���� $��0,10,0,0q�$
��Left=���Z� ��Z� .���� $ 
Horizontal=�.+��� $6��0/assets/images/baseline_dashboard_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��	Dashboard��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $<��6/assets/images/baseline_personal_injury_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Patients��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $3��-/assets/images/baseline_people_white_24dp.png��$��20��$��20��$��1,0,10,0q��� $��Users��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
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
��Left=��� $��Radio��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -   $��0,0,0,0q����	#FF1E40AF$
��Left=�$	��100��.���� $ 
Horizontal=�.+��� $-��'/assets/images/emoticon-poop-custom.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��	Fecalysis��$��Center=�$��Arial)�$��11(����	#FFF4F4F5�� -	   $��0,0,0,0q�$
��Left=�$	��100����Z� ��Z� .���� $ 
Horizontal=�.+��� $;��5/assets/images/baseline_account_circle_white_24dp.png��$��20��$��20��$��1,0,10,0q�$
��Left=��� $��Account��$��Center=�$��Arial)�$��11(����	#FFF4F4F5� -
   $  gridDataTable��$��2��$��	100,0,0,0q����	#FF1E293B$y�Visible=�.+��� $��	Fecalysis��$��Center=�$	��Top=����	#FFF4F4F5$��30(�$	��136��$
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
�������� -   $  gridAddData��
������ $	��800��$y�	Collapsed=�$��0,26,0,0q�.+��� $��ADD FECALYSIS RESULT��$��Center=�$��50(����	#FFF3E9E9$��
0,10,0,676q�$��Century Gothic)�$
��Bold"��� $��
Patient Id��$��30(�$
��Left=����	#FFF3E9E9$��20,123,0,597q�$	��155���� -   	 ��Name$	 txtPatientId��$
��Left=�$��
20,182,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Color��$��30(�$
��Left=����	#FFF3E9E9$��407,123,0,597q�$	��155���� -   $	 txtColor��$
��Left=�$��407,182,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Occult blood��$��30(�$
��Left=����	#FFF3E9E9$��20,237,0,492q�$	��180���� -   $	 txtOccultBlood��$
��Left=�$��
20,282,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��	Pus Cells��$��30(�$
��Left=����	#FFF3E9E9$��407,237,0,492q�$	��180���� -   $	 txtPusCells��$
��Left=�$��407,282,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Red Blood Cells��$��30(�$
��Left=����	#FFF3E9E9$��20,337,0,388q�$	��221��
 J� RenderTransformOrigin$
 0.5,0.5&��� -   $	 txtRedBloodCells��$
��Left=�$��
20,391,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $
��Cyst��$��30(�$
��Left=����	#FFF3E9E9$��407,337,0,388q�$	��221��$
 0.5,0.5&��� -   $	 txtCyst��$
��Left=�$��407,391,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Trophozolte��$��30(�$
��Left=����	#FFF3E9E9$��20,446,0,265q�$	��221��$
 0.5,0.5&��� -   $	 txtTrophozolte��$
��Left=�$��
20,509,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Intestinal Parasite��$��30(�$
��Left=����	#FFF3E9E9$��407,446,0,270q�$	��253��$
 0.5,0.5&��� -   $	 txtIntestinalParasite��$
��Left=�$��407,509,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Consistency��$��30(�$
��Left=����	#FFF3E9E9$��20,559,0,162q�$	��253��$
 0.5,0.5&��� -   $	 txtConsistency��$
��Left=�$��
20,617,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Pathologist��$��30(�$
��Left=����	#FFF3E9E9$��407,559,0,157q�$	��253��$
 0.5,0.5&��� -   $	 txtPathologist��$
��Left=�$��407,617,0,0q�$
 Wrap=�$	��Top=�$	��360��$��30(����	#FF075985�� $��Medical Technologist��$��30(�$
��Left=����	#FFF3E9E9$��20,673,0,170q�$	��313��$
 0.5,0.5&��� -   $	 txtMedicalTechnologist��$
��Left=�$��
20,732,0,0q�$
 Wrap=�$	��Top=�$	��747��$��30(����	#FF075985�� -   $
��SAVE��$
��Left=�$��
10,804,0,0q�$	��Top=����	#FF052E16
�������$	��478��$��58���� -   $��CANCEL��$
��Left=�$��508,803,0,0q�$	��Top=�
�������
�������$	��259��$��57��