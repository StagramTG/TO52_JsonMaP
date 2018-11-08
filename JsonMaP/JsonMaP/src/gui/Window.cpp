#include "Window.hpp"

Window::Window(): Fl_Window(854, 480, "JsonMaP - TO52")
{
	begin();

	end();
}

Window::~Window()
{
}

int Window::Run()
{
	show();
	return Fl::run();
}
