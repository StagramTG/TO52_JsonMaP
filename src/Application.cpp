/**
 * 
 * Author: Thomas Gredin
 * Date  : 6th November 2018
 * 
 * Application Entry point
 * 
 */

#include "data/JsonUtils.hpp"
#include <iostream>

int main(int argc, char** argv)
{
    Json json;

    ParseFromFile(json, "/Users/tgred/Google Drive/ShareSpace/Cours/Semestre 5/TO52/Exemple.json");

    std::cout << json["LinesCount"] << std::endl;

    return 0;
}