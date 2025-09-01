# how-to-show-drop-down-menu-in-.net-maui-chat

## Sample

```xaml

    <ContentPage.Resources>  
        <ResourceDictionary>  
            <Style TargetType="syncfusion:IncomingMessageTextView">  
                <Setter Property="ControlTemplate">  
                    <Setter.Value>  
                        <ControlTemplate x:DataType="syncfusion:TextMessage">
                            <local:CustomEffectsView Popup="{x:Reference sfPopup}" x:Name="customView" >
                                <Label  Text="{Binding Text}" HorizontalTextAlignment="Start" FontSize="14" BackgroundColor="Transparent" BindingContext="{TemplateBinding BindingContext}"/>  
                            </local:CustomEffectsView>  
                        </ControlTemplate>  
                    </Setter.Value>  
                </Setter>  
            </Style>  

            <core:SfChipGroup x:Name="chipGroup" x:Key="chipGroup" ChipStroke="Transparent" ChipStrokeThickness="0" ChipCornerRadius="0" ItemsSource="{Binding PopupItems}">  
                <core:SfChipGroup.ChipLayout>  
                    <VerticalStackLayout/>  
                </core:SfChipGroup.ChipLayout>  
                <core:SfChipGroup.ItemTemplate>  
                    <DataTemplate x:DataType="x:String">
                        <Grid Padding="5">  
                            <Label Text="{Binding .}" FontSize="14" />  
                        </Grid>  
                    </DataTemplate>  
                </core:SfChipGroup.ItemTemplate>  
            </core:SfChipGroup>

            <popup:SfPopup x:Name="sfPopup" x:Key="sfPopup" ShowFooter="False" ShowHeader="False" AutoSizeMode="Both" ShowOverlayAlways="False" Padding="10">
                <popup:SfPopup.PopupStyle>
                    <popup:PopupStyle PopupBackground="#FFFBFE"  CornerRadius="0" HasShadow="True"/>
                </popup:SfPopup.PopupStyle>

                <popup:SfPopup.ContentTemplate>
                    <DataTemplate>
                        <ContentView Content="{StaticResource chipGroup}"/>
                    </DataTemplate>
                </popup:SfPopup.ContentTemplate>
            </popup:SfPopup>  
        </ResourceDictionary>  
    </ContentPage.Resources>  

Behavior:

    this.chipGroup.ChipClicked += ChipGroup_ChipClicked;

    private void ChipGroup_ChipClicked(object? sender, EventArgs e)
    {
        if (this.popup != null && this.popup.IsOpen)
        {
            this.popup.IsOpen = false;
        }
    }

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.