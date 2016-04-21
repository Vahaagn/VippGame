#pragma once
#include "stdafx.h"

#include <SFML/Graphics.hpp>
#include "Particle.h"

class ParticleSystem : public sf::Drawable, public sf::Transformable
{
private:
	std::vector<Particle> m_particles;
	sf::VertexArray m_vertices;
	sf::Time m_lifetime;
	sf::Vector2f m_emitter;

public:
	ParticleSystem(unsigned int count);

	void setEmitter(sf::Vector2f position);
	void update(sf::Time elapsed);

private:
	virtual void draw(sf::RenderTarget& target, sf::RenderStates states) const;

	void resetParticle(std::size_t index);
};
