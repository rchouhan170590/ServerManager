   M S B A M L   `   `   `  ���� H  DServerManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ServerManagerServerManager  %    ServerManager.ManagerMainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:ServerManager       � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��25 ��� $	��20* ��� $��9* ��� $��45 �.+�� ���#000000.+��� $��0��$��Center=�$��Center=�$��17(�
�������Server Manager� $��1�� �� $��6* ��� $��6* ��� $��6* ��� $	��11* ��� $	��10* �.+��� $��1q�
���   �$��0��._�� $��1�����#1a1a1a.+��� -    ��Name$ Select_Server��$��Select Server��$
��Left=�$��	15,10,0,0q�$	��Top=�$��90��$��30��$��13(�
��������� -    ��Name$ ServerComboBox��$��30��$	��156��$
��Left=�$	��Top=�$��
202,10,0,0q�$��Center=��� -   $ Show_Server_Path��$y�Hidden=�$�� ��$
��Left=�$��	15,35,0,0q�$	��Top=�$	��356��$��25��$��10(��� $��1q�
���   �$��1��._�� $��2�����#333333.+��� -   $ Select_Database��$��Select Database��$
��Left=�$��	15,10,0,0q�$	��Top=�$	��102��$��30��$��13(�
��������� -   $ DatabaseComboBox��$
��Left=�$	��Top=�$��
202,10,0,0q�$��30��$	��156��$��Center=��� -   $ Show_Database_Path��$y�Hidden=�$�� ��$
��Left=�$��	15,35,0,0q�$	��Top=�$	��356��$��25��$��10(��� $��1q�
���   �$��2��._�� $��3�����#1a1a1a.+��� -   $ Select_File_Formate��$��Select File Extension��$
��Left=�$��	15,10,0,0q�$	��Top=�$	��126��$��30��$��13(�
��������� $
��Left=�$	��Top=�$��
198,10,0,0q�$��30��$	��162��$��Center=�.@��� -    ��Name$ XML_CheckBox��.���� .��XML�� -	   $ Config_CheckBox��.���� .��Config�� $��1q�
���   �$��3��._�� ���#333333 �� $	��10* ��� $	��10* �.+�� $��0��.+��� $��
Username :��$
��Left=�$��	15,10,0,0q�$	��Top=�$	��126��
��������� -
    ��Name$ usernametextbox��$�� ��$��198,10,0,10q�$	��162��$
��Left=�$��25��� $��1��.+��� $��
Password :��$
��Left=�$��	15,10,0,0q�$	��Top=�$	��126��
�������G� -    G�Name$ passwordtextbox��$��198,10,0,10q�$	��162��$
��Left=�$��25���� $��1q�
���   �$��4��._�� $��0�����#1a1a1a.+��� -   $ label1��$��Connection String : ��$��	15,10,0,0q�
��������� $
��Auto=�$
��Auto=�$��	15,35,0,0q�.����  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� -   $ connectionStringLabel��$+��%Server=;Database=;User Id=;Password=;��$
��Left=�$	��Top=�$��23��$��10(�
��������� -   $ Show_Project_Path��$y�Hidden=�$�� ��$
��Left=�$��	15,35,0,0q�$	��Top=�$	��360��$��25��$��10(��� $��2��$��1q�
���   �._�� $��0�����#262626.+��� -   $��m_tab_control�����#262626.@��� $��Manage Servers�����#000000
�������.��� .+��� -   $ Serevr_Name_Add_Section��$��Server Name��$
��Left=�$��	15,10,0,0q�$	��Top=�$��25��$	��100��
��������� -   $ Server_Name_TextBox��$
��Left=�$��25��$��
150,10,0,0q�	 �� TextWrapping$
	 Wrap=�$�� ��$	��Top=�$	��212���� -   $ Serevr_Value_Add_Section��$��Server Value��$
��Left=�$��	15,45,0,0q�$	��Top=�$��25��$	��100��
��������� -   $ Server_Value_TextBox��$
��left=�$��25��$��
150,45,0,0q�$
	 Wrap=�$�� ��$	��Top=�$	��212���� -   
 ��Name$
 Add_New_Server_btn��$	��Add��$
��Left=�$��
268,80,0,0q�$	��Top=�$��94��$��30���� -   $
 Delete_Server_btn��$��Delete Server��$
��Left=�$	��Top=�$	��100��$��30��$��	15,80,0,0q��� $��Manage Databases�����#000000
�������.��� .+��� -   $ Database_Name_Add_Section��$��Database Name��$
��Left=�$��	15,10,0,0q�$	��Top=�$��25��$	��100��
��������� -   $ Database_Name_TextBox��$
��Left=�$��25��$��
150,10,0,0q�$
	 Wrap=�$�� ��$	��Top=�$	��210���� -   $  Database_Value_Add_Section��$��Database Value��$
��Left=�$��	15,45,0,0q�$	��Top=�$��25��$	��100��
��������� -   $ Database_Value_TextBox��$
��Left=�$��25��$��
150,45,0,0q�$
	 Wrap=�$�� ��$	��Top=�$	��210���� -   $
 Add_New_Database_btn��$	��Add��$
��Left=�$��
254,80,0,0q�$	��Top=�$	��106��$��30���� -   $
 Delete_database_btn��$��Delete DataBase��$
��Left=�$	��Top=�$	��100��$��30��$��	15,80,0,0q��� $��1q�
���   �$��3��._�� $��3�����#1a1a1a.+��� -   $
 Replace_btn��$��Replace��$
��Left=�$��	269,5,0,0q�$	��Top=�$��94��$��30��