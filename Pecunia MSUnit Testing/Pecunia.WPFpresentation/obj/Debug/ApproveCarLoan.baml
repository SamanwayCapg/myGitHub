   M S B A M L   `   `   `  ����R  NPecunia.WPFpresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Pecunia.WPFpresentationPecunia.WPFpresentation  5   	   ,    &Pecunia.WPFpresentation.ApproveCarLoan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Pecunia.WPFpresentation     5   	   -   5          � Title$  ApproveCarLoan��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $��83��6@   $��	10,25,0,0q�6L   $	��Top=�6_   $	��772��6w   6�   �� 5   
   $��	Loan ID: ��6   $
��Left=�6$   $��
85,136,0,0q�6?   $	��Top=�6S   �� 5   
   -   5         ��Name$ CarLoanIDtextBox��5      $
��Left=�6-   $��23��6H   $��148,140,0,0q�6T    �� TextWrapping$
 Wrap=�6i   $��Enter Car Loan ID��6}   $	��Top=�6�   $	��199��6�   �� 5   
   -   5         ��Name$ 	searchBtn��5      $��Search��6$   $
��Left=�65   $��374,140,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5         ��Name$ statusComboBox��5      $
��Left=�6+   $��362,184,0,0q�6F   $	��Top=�6[   $	��120��6s   .@�5      �� $��APPLIED��6   $
��Left=�6-   $	��118��6H   �� 5      $��
PROCESSING��6   $
��Left=�60   $	��118��6K   �� 5      $��REJECTED��6   $
��Left=�6.   $	��118��6I   �� 5      $��APPROVED��6   $
��Left=�6.   $	��118��6I   �� 5      $��INVALID��6   $
��Left=�6-   $	��118��6H   5      �� 5   
   $��Update Status��6   $
��Left=�6(   $��263,184,0,0q�6C   $	��Top=�6X   �� 5   
   -   5        $ 	submitBtn��5      $��SUBMIT��6$   $
��Left=�65   $��407,269,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ backBtn��5      $
��BACK��6"   $
��Left=�61   $��263,269,0,0q�6L   $	��Top=�6a   $��75��6y   6�   5!      5"      