#pragma once
#include <SFML/Graphics.hpp>

#define ESPRESSO "espresso"
#define LATTE "latte"
#define CAPPUCINO "cappucino"

namespace Liquids{

class Liquid
{
public:

    sf::Color color;
    std::string name;

    int ml;



};







}