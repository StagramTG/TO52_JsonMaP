#pragma once

#include <FL/Fl.H>
#include <FL/Fl_Window.H>

class Window: public Fl_Window
{
private:

public:
	Window();
	~Window();

	int Run();
};