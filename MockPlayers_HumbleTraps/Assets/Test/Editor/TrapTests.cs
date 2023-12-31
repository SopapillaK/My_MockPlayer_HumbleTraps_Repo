using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests 
{
    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ReducesHealthByOne()
    {
        //Arrange
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>(); 
        characterMover.IsPlayer.Returns(true);

        //Act
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        //Assert
        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void NpcEntering_NpcTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);
        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void ZombieEntering_EnemyTargetedTrap_CheckIfHealthIsZero()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Zombie);
        Assert.AreEqual(0, characterMover.Health);
    }

    [Test]
    public void VampireEntering_EnemyTargetedTrap_CheckIfHealthIsZero()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Vampire);
        Assert.AreEqual(0, characterMover.Health);
    }
}
