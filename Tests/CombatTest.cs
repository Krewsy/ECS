using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECS;
using Tests.Test;

namespace Tests
{
    class CombatTest
    {

        public CombatTest()
        {
            EntityManager em = new EntityManager();

            // create test entities
            for (int i = 0; i < 5; i++)
            {
                em.CreateEntity(i.ToString());
                em.AddComponent<HealthComponent>(i.ToString());
            }

            Entity currentEnemy = new Entity();
            while (true)
            {
                if (em.activeEntities.Any())
                {
                    if (em.activeEntities.Contains(currentEnemy))
                    {
                        Console.WriteLine("How much damage would you like to do?");

                        Console.WriteLine($"Enemy {currentEnemy.id} current health: {em.GetComponent<HealthComponent>(currentEnemy.id).HP}");
                        string input = Console.ReadLine();

                        int dmg;
                        if (Int32.TryParse(input, out dmg))
                        {
                            int enemyHP = em.GetComponent<HealthComponent>(currentEnemy.id).HP;

                            em.GetComponent<HealthComponent>(currentEnemy.id).HP -= dmg;
                            enemyHP -= dmg;

                            if (enemyHP <= 0)
                            {
                                Console.WriteLine($"{currentEnemy.id} killed!");
                                em.RemoveEntity(currentEnemy.id);
                            }
                        }
                    }
                    else
                    {
                        var rand = new Random();
                        int index = rand.Next(em.activeEntities.Count);
                        currentEnemy = em.activeEntities[index];
                    }
                }
                else
                {
                    Console.WriteLine("Congratulations! You have defeated the entire group!");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
