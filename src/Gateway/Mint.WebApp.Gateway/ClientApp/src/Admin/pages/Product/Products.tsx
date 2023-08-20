import { FC, ReactNode, useState } from 'react';
import { ButtonGroup, Card, CardBody, CardHeader, Col, DropdownItem, DropdownMenu, DropdownToggle, Row, UncontrolledDropdown } from 'reactstrap';
import Loader from '../../../components/Common/Loader';
import { Colors } from '../../../services/types/ICommon';

const Products: FC<ReactNode> = () => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isFilterOpen, setIsFilterOpen] = useState<boolean>(false);

    const handleFilterClick = () => setIsFilterOpen(!isFilterOpen);

    return (
        <div className={"page-content"}>
            <Card>
                <CardHeader>
                    <h2  className={"mb-0"}>
                        Управление продуктами
                    </h2>
                </CardHeader>
                <CardBody>
                    {isLoading ? (
                        <Loader color={Colors.success} isCenter={true} />
                    ) : (
                        <Row>
                            <Col lg={12}>
                                <div className={"d-flex align-items-center"}>
                                <ButtonGroup className={"me-2"}>
                  <UncontrolledDropdown>
                    <DropdownToggle
                      tag={"button"}
                      className={"btn btn-outline-success"}
                    >
                      <i className={"ri-settings-4-line"}></i>
                    </DropdownToggle>
                    <DropdownMenu className={"dropdown-menu-md p-2"}>
                      <DropdownItem header>Вкл/Выкл столбец</DropdownItem>
                    </DropdownMenu>
                  </UncontrolledDropdown>
                </ButtonGroup>
                                    <button
                                        className={"me-2 fs-14 btn btn-outline-success"}
                                        onClick={handleFilterClick}
                                    >
<i className={"ri-filter-2-line"}></i>
                                    </button>
                                </div>
                            </Col>
                        </Row>
                    )}
                </CardBody>
            </Card>
        </div>
    );
}

export default Products;
