# ------------------------------------
# JsonMaP application makefile
#
# Author : Thomas Gredin
# Date   : 6th November 2018
# ------------------------------------

GCC  = g++
NAME = JsonMaP

# Project source files
SRC  = src/Application.cpp

out:
	$(GCC) -o $(NAME) $(SRC)