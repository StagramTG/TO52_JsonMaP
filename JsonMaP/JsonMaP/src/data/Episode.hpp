#pragma once

#include <vector>

#include "../data/JsonUtils.hpp"
#include "Character.hpp"
#include "Action.hpp"

class Episode
{
private:
	std::string title;
	Uint line_count;

	std::vector<Character*> characters;
	std::vector<Action*> actions;

public:
	Episode();
	~Episode();

	static Episode* CreateFromJson(Json pdata);
};

