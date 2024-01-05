#pragma once
#include <SFML/Graphics.hpp>
#include "liquid.hpp"

namespace Liquids{

class Water : public Liquid
{
public:

    Water(int ml_)
    {
        ml = ml_;
        color = sf::Color(149, 187, 222);
        name = "water";
    };


};


}