#pragma once
/**
 *
 * Author : Thomas Gredin
 * Date   : 6th November 2018
 *
 * Json utils functions.
 *
 */

#include <string>
#include <fstream>

 /** For convenience we create this notation */
#include <nlohmann/json.hpp>
using Json = nlohmann::json;


class JsonUtils
{
public:
	static bool ParseFromFile(Json& pjson, std::string pfile);
};