#pragma once

#include <vector>
#include "../data/JsonUtils.hpp"

class Action
{
private:
	Uint line;
	std::vector<Uint> characters_id;
	std::vector<Uint> targets_id;

public:
	Action();
	~Action();

	static Action* CreateFromJson(Json pdata);
};