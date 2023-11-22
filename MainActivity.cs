namespace Buttons_Labels_TextBoxesAndroid
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        AutoCompleteTextView Weekend_textView;

        CheckBox Game_CheckBox;
        CheckBox Reading_CheckBox;
        CheckBox Cooking_CheckBox;
        Button CheckBox_Selecion_Button;
        RadioButton male_RB;
        RadioButton female_RB;
        RadioButton Other_RB;
        Button Gender_selection;

        EditText read_data_Text;
        Button Btn_Read_Data;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Auto Complete Text View
            var weekday = Resources.GetStringArray(Resource.Array.auto_fill_array);
            Weekend_textView = FindViewById<AutoCompleteTextView>(Resource.Id.Auto_Cpt_Text_View);
            Weekend_textView.Adapter = new ArrayAdapter<string>(this,Android.Resource.Layout.TestListItem,weekday);

            // Check Box
            Game_CheckBox = FindViewById<CheckBox>(Resource.Id.checkBox_Game);
            Cooking_CheckBox = FindViewById<CheckBox>(Resource.Id.checkBox_Cooking);
            Reading_CheckBox = FindViewById<CheckBox>(Resource.Id.checkBox_Reading);
            CheckBox_Selecion_Button = FindViewById<Button>(Resource.Id.Selection_CheckBox);
            CheckBox_Selecion_Button.Click += OnSelection_Button_Click;

            //Radio Button
            male_RB = FindViewById<RadioButton>(Resource.Id.rb_Male);
            female_RB = FindViewById<RadioButton>(Resource.Id.rb_Female);
            Other_RB = FindViewById<RadioButton>(Resource.Id.rb_Other);
            Gender_selection = FindViewById<Button>(Resource.Id.Selection_Gender);
            Gender_selection.Click += Gender_selection_Click;


            //Read File's content
            read_data_Text = FindViewById<EditText>(Resource.Id.Read_Data_Edit_Text);
            Btn_Read_Data = FindViewById<Button>(Resource.Id.Read_Data_Btn);
            Btn_Read_Data.Click += Btn_Read_Data_Click;

        }

        private void Btn_Read_Data_Click(object? sender, EventArgs e)
        {
            string content;
            using (StreamReader sr = new StreamReader(Assets.Open("Read_Data.txt")))
            {
                content = sr.ReadToEnd();
            }
             read_data_Text.Text = content;
        }

        private void Gender_selection_Click(object? sender, EventArgs e)
        {
            if(male_RB.Checked)
            {
                Toast.MakeText(this, "Male is the selcted as Gender", ToastLength.Long).Show();
            }
            else if(female_RB.Checked)
            {
                Toast.MakeText(this, "Female is the selcted as Gender", ToastLength.Long).Show();
            }
            else if(Other_RB.Checked)
            {
                Toast.MakeText(this, "Other is the selcted as Gender", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Nothing is selected", ToastLength.Long).Show();
            }
        }

        public void OnSelection_Button_Click(object sender, EventArgs e)
        {
            if (Game_CheckBox.Checked)
            {
                Toast.MakeText(this,"Playing Game is the selcted Hobby", ToastLength.Long).Show();
            }
            if(Cooking_CheckBox.Checked)
            {
                Toast.MakeText(this, "Cooking is the selcted Hobby", ToastLength.Long).Show();
            }
            if (Reading_CheckBox.Checked)
            {
                Toast.MakeText(this, "Reading is the selcted Hobby", ToastLength.Long).Show();
            }
        }
    }
}