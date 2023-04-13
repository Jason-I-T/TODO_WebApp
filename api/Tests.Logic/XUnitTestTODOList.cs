namespace Tests.Logic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

// Necessary Layers
using ModelLayer;
using LogicLayer;
using DataLayer;

public class XUnitTestTODOList
{
    // Test Show TODO List
    [Fact]
    public void ShowTODOList() {
        // Arrange
        ITodoListData iTodoData = new TodoListData();
        
        // Act
        List<TodoTask> dbTasks = iTodoData.GetTodoList(); 

        // Assert
        Assert.True(dbTasks is not null);
    }

    // TODO Test Add to TODO list
    // TODO Test Delete from TODO list
    // TODO Test Mark as Complete
    // TODO Test Mark as Incomplete
}