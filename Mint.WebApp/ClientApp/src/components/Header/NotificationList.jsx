import React, { useState } from 'react';
import { Col, Dropdown, DropdownMenu, DropdownToggle, Row } from 'reactstrap';

const NotificationList = () => {
    const [isNotifyDropdown, setIsNotifyDropdown] = useState(false);

    const toggleNotifyDropdown = () => {
        setIsNotifyDropdown(!isNotifyDropdown);
    };

    return (
        <React.Fragment>
            <Dropdown
                isOpen={isNotifyDropdown}
                toggle={toggleNotifyDropdown}
                className="topbar-head-dropdown ms-1 header-item"
            >
                <DropdownToggle
                    type="button"
                    tag="button"
                    className="btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
                >
                    <i className='bx bx-bell fs-22'></i>
                    <span className="position-absolute topbar-badge fs-10 translate-middle badge rounded-pill bg-danger">
                        3 <span className="visually-hidden">unread messages</span>
                    </span>
                </DropdownToggle>
                <DropdownMenu className="dropdown-menu-lg dropdown-menu-end p-0">
                    <div className="dropdown-head bg-primary bg-pattern rounded-top">
                        <div className="p-3">
                            <Row className="align-items-center">
                                <Col>
                                    <h6>
                                        Уведомления
                                    </h6>
                                </Col>
                                <div className="col-auto dropdown-tabs">
                                    <span className="badge badge-soft-light fs-13">3 New</span>
                                </div>
                            </Row>
                        </div>
                    </div>
                </DropdownMenu>
            </Dropdown>
        </React.Fragment>
    );
}

export default NotificationList;
