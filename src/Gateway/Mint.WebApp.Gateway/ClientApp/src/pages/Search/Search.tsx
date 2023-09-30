import React, { FC, useEffect } from "react";
import { Container } from "reactstrap";
import { useParams } from "react-router-dom";

const Search: FC = () => {
  const params = useParams();

  useEffect(() => {
    console.log(params.query);
  }, [params]);

  return (
    <div className={"page-content"}>
      <Container fluid></Container>
    </div>
  );
};

export default Search;
