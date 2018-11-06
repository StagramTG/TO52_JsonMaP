/**
 * 
 * Author: Thomas Gredin
 * Date  : 6th November 2018
 * 
 * Application Entry point
 * 
 */

#include "data/JsonUtils.hpp"
#include <stdio.h>

int main(int argc, char** argv)
{
    Json json;
    printf("size %d", json.size());

    ParseFromFile(json, "test");

    printf("size %d", json.size());

    return 0;
}