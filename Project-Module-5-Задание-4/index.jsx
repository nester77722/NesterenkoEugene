var person = function (boss, people, name)
{
    this.boss = boss;
    this.people = people;
    this.name = name;
}

let employees = [];

var topBoss = new person(null, null, "Начальник завода");
var testBoss = new person(topBoss, null, "Начальник сектора");

var employee1 = new person(testBoss, null, "Работяга Андрей");
var employee2 = new person(testBoss, null, "Работяга Виталий");

employees.push(employee1);
employees.push(employee2);

testBoss.people = employees;


class Application extends React.Component
{
    render()
    {
        return <Employee data={testBoss}/>
    }
}

class Employee extends React.Component
{
    constructor(props)
    {
        super(props)

        this.state =
        {
            person: this.props.data
        }

        this.onSwitchToEmployee = this.onSwitchToEmployee.bind(this);
    }

    onSwitchToEmployee(employee)
    {
        if (employee.people == null && this.state.person != employee.boss)
        {
            employee.people = new Array(this.state.person);
        }
        
        this.setState({ person: employee});
    }

    onDeleteEmployee(employee)
    {
        if (employee.boss == null)
        {
            alert("Нельзя уволить этого работягу!");
            return;
        }

        if (employee.people != null)
        {
            if (employee.boss.people == null)
            {
                employee.boss.people = new Array();
            }
            for (let i = 0; i < employee.people.length; i++)
            {
                employee.boss.people.push(employee.people[i]);
                employee.people[i].boss = employee.boss;
            }
        }

        if (employee.boss.people.includes(employee))
        {
            let currentEmployeePosition = 0;
            for (let i = 0; i < employee.boss.people.length; i++)
            {
                if (employee.boss.people[i] == employee)
                {
                    currentEmployeePosition = i;
                    break;
                }
            }

            employee.boss.people.splice(currentEmployeePosition, 1);
        }

        this.setState({ person: employee.boss});
    }

    render()
    {
        let currentEmployees = this.state.person.people?.map(employee => <button onClick={() => this.onSwitchToEmployee(employee)}>{employee.name}</button>)
    return <div>
        <>Текущий работник: <strong>{this.state.person.name} </strong><br /> </>
        <>Его начальник: </>
        <button onClick={() => this.onSwitchToEmployee(this.state.person.boss)}>{(this.state.person.boss == null) ? "У этого работяги нет начальника" : this.state.person.boss.name}</button> <br />
        <> Подчиненные: <br /> { currentEmployees }</> <br />
        <button id="deleteEmployeeButton" onClick={() => this.onDeleteEmployee(this.state.person)}>Вышвырнуть лентяя!</button>
    </div>
    }
}

ReactDOM.render(
    <Application />,
    document.getElementById("app")
)