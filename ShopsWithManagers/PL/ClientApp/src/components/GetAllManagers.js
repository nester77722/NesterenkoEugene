import React, { useEffect, useState } from 'react';
import axios from 'axios';

export default function AllManagers() {
    const [managers, setManagers] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [managersPerPage] = useState(3);
    const [totalManagers, setTotalManagers] = useState(0);
    const [status, setStatus] = useState("");
    const [shopId, setShopId] = useState("");
    const [isTimeFilterEnabled, setTimeFilter] = useState(false);

    const getAllManagers = async () => {
        const response = await axios.get('/api/managers/all-managers', {
            params: {
                currentPage: currentPage,
                pageSize: managersPerPage,
                isTimeFilterEnabled: isTimeFilterEnabled,
                shopId: Number(shopId),
                status: status
            }
        }
        );
        setManagers(response.data.managers);
        setTotalManagers(response.data.totalManagers);
    }

    useEffect(() =>{
        getAllManagers();
    }, [currentPage])

     useEffect(() => {
         getAllManagers();
         setCurrentPage(1);
    }, [isTimeFilterEnabled])

    useEffect(() => {
        getAllManagers();
        setCurrentPage(1);
    }, [shopId])

    useEffect(() => {
        getAllManagers();
        setCurrentPage(1);
    }, [status])

    useEffect(() => {
        getAllManagers();
    }, [])

    function paginate() {
        let buttons = [];
        for (let i = 1; i <= Math.ceil(totalManagers / managersPerPage); i++) {
            buttons.push(i);
        }

        return buttons;
    }

    function onPageHandle(pageNumber) {
        setCurrentPage(pageNumber);
    }

    function handleTimeFilterChange(){
        setTimeFilter(!isTimeFilterEnabled);
    }

    function handleShopIdChange(e){
        setShopId(e.target.value);
    }

    function handleStatusChange(e){
        setStatus(e.target.value);
    }


    return (
        <div>
            <h1>Managers:</h1>
            <div className="filters">
                <div>
                    <label>Input shop id</label>
                    <input type="text" value={shopId} onChange={handleShopIdChange}></input>
                </div>

                <div>
                    <label>Input status</label>
                    <input type="text" value={status} onChange={handleStatusChange}></input>
                </div>

                <div>
                    <input type="checkbox" id="by-time" name="by-time" onChange={handleTimeFilterChange} />
                    <label for="by-time">By time</label>
                </div>
            </div>
            <ul>
                {
                    managers.map((manager) => (
                        <li>
                            Name: {manager.name} <br />
                            Id: {manager.id} <br />
                            Status: {manager.status} <br />
                            Current Shop Id: {manager.currentShopId} <br />
                        </li>
                    ))
                }
                {
                    paginate().map((number) => (
                        <button onClick={() => onPageHandle(number)}>{number}</button>
                    ))
                }
            </ul>
        </div>
    )
}
