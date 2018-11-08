#include "ApplicationWindow.hpp"

ApplicationWindow::ApplicationWindow(): Fl_Window(854, 480, "JsonMaP - TO52")
{
	begin();

	/* Buttons */
	btn_choose_file = std::make_unique<Fl_Button>(20, 20, 200, 25, "Choisir un fichier Json");

	btn_launch_sim = std::make_unique<Fl_Button>(20, 55, 200, 25, "Lancer la simulation");
	btn_launch_sim->deactivate();

	btn_choose_file->callback(ChooseFile_Callback);
	btn_launch_sim->callback(LaunchSim_Callback);

	/* Texts */
	out_file_path = std::make_unique<Fl_Output>(230, 40, 614, 25, "Chemin du fichier sélectionné : ");
	out_file_path->align(FL_ALIGN_TOP_LEFT);
	
	end();
}

ApplicationWindow::~ApplicationWindow()
{
}

int ApplicationWindow::Run()
{
	show();
	return Fl::run();
}

/*========================================================
	CALLBACKS
========================================================*/

void ChooseFile_Callback(Fl_Widget * w, void* v)
{
	std::cout << "Choose file" << std::endl;
}

void LaunchSim_Callback(Fl_Widget * w, void* v)
{
	std::cout << "Launch sim" << std::endl;
}