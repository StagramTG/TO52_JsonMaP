#pragma once

#include "../data/JsonUtils.hpp"

class Character
{
private:
	std::string name;
	Uint id;

public:
	Character();
	~Character();

	static Character* CreateFromJson(Json pdata);
};