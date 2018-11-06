/**
 * 
 * Author : Thomas Gredin
 * Date   : 6th November 2018
 * 
 * Json utils functions.
 * 
 */

#include <string>
#include <ifstream>

/** For convenience we create this notation */
#include "../../vendors/json.hpp"
using Json = nlohmann::json;

bool ParseFromFile(Json& pjson, std::string pfile);