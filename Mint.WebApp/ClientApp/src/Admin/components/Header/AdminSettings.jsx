import React, { useState } from 'react';
import { Dropdown, DropdownToggle } from 'reactstrap';

const AdminSettings = () => {
    const [isOpen, setIsOpen] = useState(false);

    const toggleSeacrh = () => {
        setIsOpen(!isOpen);
    };

    return (
        <React.Fragment>
            <Dropdown
                isOpen={isOpen}
                toggle={toggleSeacrh}
                className='topbar-head-dropdown ms-1 header-item'
            >
                <DropdownToggle
                    type={"button"}
                    tag={"button"}
                    className='btn btn-icon btn-topbar btn-ghost-secondary rounded-circle'
                >
                    <i className="ri-settings-3-line fs-22"></i>
                </DropdownToggle>
            </Dropdown>
        </React.Fragment>
    );
}

export default AdminSettings;
