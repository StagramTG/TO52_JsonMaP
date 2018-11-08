#pragma once

#define WIN32

#include <FL/Fl.H>
#include <FL/Fl_Window.H>
#include <FL/Fl_Box.H>
#include <FL/Fl_Output.H>
#include <FL/Fl_Button.H>
#include <FL/Fl_File_Chooser.H>

#include <iostream>
#include <memory>

/* Buttons' Callbacks */
void ChooseFile_Callback(Fl_Widget* w, void* v);
void LaunchSim_Callback(Fl_Widget* w, void* v);

class ApplicationWindow: public Fl_Window
{
private:
	std::unique_ptr<Fl_Button> btn_choose_file;
	std::unique_ptr<Fl_Button> btn_launch_sim;

	std::unique_ptr<Fl_Output> out_file_path;

	std::unique_ptr<Fl_File_Chooser> fc_json_file;

public:
	ApplicationWindow();
	~ApplicationWindow();

	int Run();

	/* Friend methods */
	friend void ChooseFile_Callback(Fl_Widget* w, void* v);
};