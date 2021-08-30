class Application extends React.Component
{
    render()
    {
        return <Table />
    }
}


class Table extends React.Component
{

    constructor(props)
    {
        super(props);

        this.initializeState();
        this.initializeDataArray();
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onAddColumn = this.onAddColumn.bind(this);
        this.onRemoveColumn = this.onRemoveColumn.bind(this);
        this.onAddRow = this.onAddRow.bind(this);
        this.onRemoveRow = this.onRemoveRow.bind(this);
    }

    initializeState()
    {
        this.state =
        {
            rows: 4,
            columns: 4,
            data: null,
        }
    }

    initializeDataArray()
    {
        this.state.data = [];
        for (let index = 0; index < this.state.rows; index++)
        {
            this.state.data[index] = [];
        }
    }

    onChangeHandler(rowNumber, columnNumber, value)
    {
        var newTable = [...this.state.data];
        newTable[rowNumber][columnNumber] = value;
        this.setState({ data: newTable });
    }

    onAddColumn(columnNumber)
    {
        let newTable = [...this.state.data];

        for (let i = 0; i < this.state.rows; i++)
        {
            newTable[i].push(0);
            for (let j = newTable[i].length - 1; j > columnNumber + 1; j--)
            {
                let tmp = newTable[i][j];
                newTable[i][j] = newTable[i][j - 1];
                newTable[i][j - 1] = tmp;
            }
        }

        this.setState({ columns: this.state.columns + 1 });
        this.setState({ data: newTable });
    }

    onRemoveColumn(columnNumber)
    {
        if (this.state.columns != 1)
        {
            let newTable = [];
            for (let index = 0; index < this.state.rows; index++)
            {
                newTable[index] = [];
            }

            let counter;
            for (let i = 0; i < this.state.rows; i++)
            {
                counter = 0;
                for (let j = 0; j < this.state.columns; j++)
                {
                    if (j != columnNumber)
                    {
                        newTable[i][counter] = this.state.data[i][j];
                        counter = counter + 1;
                    }
                }
            }

            this.setState({ columns: this.state.columns - 1 });
            this.setState({ data: newTable });
        }
        else
        {
            alert("Stop it, get some help!");
        }

    }

    onAddRow(rowNumber)
    {
        let newTable = [...this.state.data];
        newTable.push([]);

        for (let j = 0; j < this.state.columns; j++)
        {
            newTable[newTable.length - 1][j] = 0;
        }

        for (let i = newTable.length - 1; i > rowNumber + 1; i--)
        {
            let tmp = newTable[i];
            newTable[i] = newTable[i - 1];
            newTable[i - 1] = tmp;
        }

        this.setState({ rows: this.state.rows + 1 });
        this.setState({ data: newTable });
    }

    onRemoveRow(rowNumber)
    {
        if (this.state.rows != 1)
        {
            let newTable = [];
            for (let index = 0; index < this.state.rows; index++)
            {
                newTable[index] = [];
            }

            let counter = 0;
            for (let i = 0; i < this.state.rows; i++)
            {
                if (i != rowNumber)
                {
                    for (let j = 0; j < this.state.columns; j++)
                    {
                        newTable[counter][j] = this.state.data[i][j];
                    }

                    counter = counter + 1;
                }
            }

            this.setState({ data: newTable });
            this.setState({ rows: this.state.rows - 1 });
        }
        else
        {
            alert("Stop it, get some help!");
        }
    }

    render()
    {
        let table = [];
        let columnsButtons = [];

        for (let index = 0; index < this.state.rows; index++)
        {
            table[index] = [];
        }

        for (let i = 0; i < this.state.rows; i++)
        {
            for (let j = 0; j < this.state.columns; j++)
            {
                if (j == this.state.columns - 1)
                {
                    table[i][j] = <> <input type="text" size="1" onChange={event => this.onChangeHandler(i, j, event.target.value)} value={this.state.data[i][j]}></input> <button onClick={() => this.onAddRow(i)}>+</button><button onClick={() => this.onRemoveRow(i)}>-</button> <br /> </>;
                }
                else
                {
                    table[i][j] = <input type="text" size="1" onChange={event => this.onChangeHandler(i, j, event.target.value)} value={this.state.data[i][j]}></input>;
                }
            }
        }

        for (let cb = 0; cb < this.state.columns; cb++)
        {
            columnsButtons[cb] = <><button onClick={() => this.onAddColumn(cb)} >+</button><button onClick={() => this.onRemoveColumn(cb)}>-</button>  </>;
        }

        return <> {columnsButtons} <br /> {table}</>
    }
}

ReactDOM.render(
    <Application />,
    document.getElementById("app")
)
