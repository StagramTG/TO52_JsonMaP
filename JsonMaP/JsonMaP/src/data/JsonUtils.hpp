#pragma once
/*
	Author: Thomas Gredin
	Date: 7th November 2018

	Json utils functions.
*/

#include <string>
#include <fstream>

 /** For convenience */
#include <nlohmann/json.hpp>
using Json = nlohmann::json;
using Uint = unsigned int;

class JsonUtils
{
public:
	/*
		Parse given Json file and file given Json object with extracted data.
	*/
	static bool ParseFromFile(Json& pjson, std::string pfile);
};