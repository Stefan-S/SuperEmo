SuprEmo (SuperEmo)
========



SuprEmo is a project made by Stefan Spasovski, Vladimir Popovski and Monika Simjanoska as a part of the course Information Processing in Biological Systems during the master studies in Intelligent Systems Engineering.

Live version can be found at [AppHarbour](http://superemoservice.apphb.com/).

The project's objective is creating an emotional learning based agent, which is capable of surviving in a dynamic environment. When a new agent is born, it follows only the "basic" insticts, the money affinity and the death avoidance, coded in its genome. Confronting the real life (the environment), the agent learns how to survive in a sequence of trials. Its behaviour is highly individual and non deterministic, since it is controlled by the two crucial humanoid parameters, sensitivity and curiosity. The more sensitive the agent is, the greater is the environment impact during the learning process. The more curious the agent is, the greater is the chance to get itself involved in an unexpected situation.

![cube1](https://raw.github.com/Stefan-S/SuperEmo/master/SuprEmo/Images/cube.PNG)
![cube2](https://raw.github.com/Stefan-S/SuperEmo/master/SuprEmo/Images/cube2.PNG)
![cube3](https://raw.github.com/Stefan-S/SuperEmo/master/SuprEmo/Images/cube3.PNG)

Agent's genome is a 5D space that consists of agent's three possible actions (jump, forward, slide), three possible positions from which the action was performed (high, stand, low) and six possible states (walkable, walkable gold low, walkable gold high, danger, danger gold, obstacle) defined as a triple of the past environment surrounding (t0), the current environment surrounding (t1) and the future environment surrounding (t2). The figures below depict the graphical representation of the agent's genome. The fisrt figure depicts the agent's genome as a 3D cube where the depth is the actions (A), the width is the past positions of the agent (P) and the height is the past surroundings (t0). The middle figure is a six-layer presentation of the past surroundings, showing the current changings in the genome as the agent acts in the environment. It is disassembled in the last figure as a matrix presenting the changes in t1 and t2, which we defined above.


