import React from 'react';
import { UncontrolledTooltip } from 'reactstrap';

const Popover = ({ id, placement, text }) => {
    return (
        <>
          <i className='ri-question-fill' id={id}></i> 
          <UncontrolledTooltip
            placement={placement}
            target={id}
          >
            {text}
          </UncontrolledTooltip> 
        </>
    );
}

export default Popover;
