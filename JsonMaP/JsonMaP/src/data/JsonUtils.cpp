#include "JsonUtils.hpp"

bool JsonUtils::ParseFromFile(Json & pjson, std::string pfile)
{
	std::ifstream stream;
	stream.open(pfile);

	if (!stream.is_open())
	{
		return false;
	}

	stream >> pjson;

	return true;
}
